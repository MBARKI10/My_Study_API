using myStudyWP.Models;
using myStudyWP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace myStudyWP.Services
{
    class PostDataService
    {
        private const string BaseUrl = @"http://localhost:50296/api/Posts/";
        public string ErrorMessage = "";

        PostCommentDataService commentsData = new PostCommentDataService();
        LikeDataService likesData = new LikeDataService();

        public async Task<List<Post>> GetPostsAsync()
        {
            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var postsList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse);

            return postsList;
        }


        public async Task<Post> GetPostAsync(int id)
        {

            var httpClient = new HttpClient();

            var jsonResponse = await httpClient.GetStringAsync(BaseUrl);

            var post = JsonConvert.DeserializeObject<Post>(jsonResponse);

            return post;
        }

        public async Task<bool> AddPostAsync(Post post)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(post);

            HttpContent httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(BaseUrl), httpContent);

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = response.ReasonPhrase.ToString();
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePostAsync(int id)
        {

            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(BaseUrl + id);

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = response.ReasonPhrase.ToString();
                return false;
            }

            return true;
        }

        public async void getAllPosts(double width)
        {
            List<Post> ListPosts = await GetPostsAsync();

            List<PostComment> listComments = await commentsData.GetCommentsAsync();
            List<Like> listLikes = await likesData.GetLikesAsync();

            List<Post> lsFinal = AddCredsToPosts(ListPosts, listComments, listLikes);

            ViewModel.Statique._PostViewModel.InsertPosts(lsFinal, width);
        }

        private List<Post> AddCredsToPosts(List<Post> ListPosts, List<PostComment> listComments, List<Like> listLikes)
        {
            foreach (Post post in ListPosts)
            {
                foreach (PostComment comment in listComments)
                {
                    if (post.IdPost.Equals(comment.IdPost))
                    {
                        post.Comments.Add(comment);
                    }
                }

                foreach (Like like in listLikes)
                {
                    if (post.IdPost.Equals(like.IdPost))
                    {
                        post.Likes.Add(like);
                    }
                }
            }

            return ListPosts;
        }
        public async Task<Post> getpost(Post post,double width)
        {
            List<PostComment> listComments = await commentsData.GetCommentsAsync();
            List<Like> listLikes = await likesData.GetLikesAsync();
            return AddCredsToPost(post, listComments, listLikes, width);

        }
        public Post AddCredsToPost(Post postt, List<PostComment> listComments, List<Like> listLikes, double width)
        {
            Post post = postt;
            post.Comments.Clear();
            post.Likes.Clear();
            foreach (PostComment comment in listComments)
            {
                if (postt.IdPost.Equals(comment.IdPost))
                {
                    post.Comments.Add(comment);
                }
            }
            Statique._PostCommentViewModel.InsertComments(post.Comments,width);

            foreach (Like like in listLikes)
            {
                if (postt.IdPost.Equals(like.IdPost))
                {
                    post.Likes.Add(like);
                }
            }
            Statique._LikeViewModel.InsertLikes(post.Likes, width);
            return post;
        }

        public async void getMyGroupPosts(double width)
        {
            List<Post> ListPosts = await GetPostsAsync();
            List<Post> posts = new List<Post>();
            foreach(Post post in ListPosts)
            {
                if (post.IdSubgroup == Statique._LoggedUser.IdSubgroup)
                    posts.Add(post);
            }
            ViewModel.Statique._PostViewModel.InsertPosts(posts, width);
        }

        public async Task EditPostAsync(Post post)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(post);

            var httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync(BaseUrl + post.IdPost, httpContent);
        }

        public async void getMyPosts(double width)
        {
            List<Post> ListPosts = await GetPostsAsync();
            List<Post> posts = new List<Post>();
            foreach (Post post in ListPosts)
            {
                if (post.IdUser == Statique._LoggedUser.IdUser)
                    posts.Add(post);
            }
            ViewModel.Statique._PostViewModel.InsertPosts(posts, width);
        }

        public bool iLike(Post post)
        {
            List<Like> likes = post.Likes.ToList();
            foreach(Like like in likes)
            {
                if(like.IdUser == Statique._LoggedUser.IdUser)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
