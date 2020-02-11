using MyStudyAPI.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace MyStudyAPI.Models
{
    [DataContract]
    [Serializable]
    public class Subgroup
    {
        public Subgroup()
        {
            Days = new List<Day>();
            Posts = new List<Post>();
        }

        [DataMember]
        [Key]
        public int IdSubgroup { get; set; }

        [DataMember]
        [Required]
        public String Label { get; set; }


        public virtual ICollection<Day> Days { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }



    public interface ISubgroupRepository
    {
        ICollection<string> getSubgroupsLabel();
        Task AddAllSubgroup();
        //void getSubgroup(string subgroupName);
    }

    public class SubgroupRepository : ISubgroupRepository
    {
        private DContext db = new DContext();

        private string xmlFilename = null;
        private XmlDocument xmlDoc = null;

        public SubgroupRepository()
        {
            try
            {
                // Determine the path to the PostsData.xml file.
                xmlFilename = HttpContext.Current.Server.MapPath("~/app_data/ClacessFile.xml");

                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilename);
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        public ICollection<string> getSubgroupsLabel()
        {
            ICollection<string> lsLabel = new List<string>();

            XmlNodeList SubgroupList = xmlDoc.DocumentElement.SelectNodes("/Students_Timetable/Subgroup");
            foreach (XmlNode groupNode in SubgroupList)
            {
                lsLabel.Add(groupNode.Attributes.GetNamedItem("name").InnerText);
            }

            return lsLabel;
        }

        public async void getSubgroup(string subgroupName)
        {
            try
            {
                XmlNodeList SubgroupList = xmlDoc.DocumentElement.SelectNodes("/Students_Timetable/Subgroup");
                foreach (XmlNode groupNode in SubgroupList)
                {

                    if (subgroupName.Equals(groupNode.Attributes.GetNamedItem("name").InnerText))
                    {
                        Subgroup subgroup = new Subgroup();
                        subgroup.Label = groupNode.Attributes.GetNamedItem("name").InnerText;

                        XmlNodeList DaysList = groupNode.SelectNodes("Day");
                        foreach (XmlNode dayNode in DaysList)
                        {
                            Day day = new Day();

                            day.Label = dayNode.Attributes.GetNamedItem("name").InnerText;

                            XmlNodeList HoursList = dayNode.SelectNodes("Hour");

                            foreach (XmlNode hourNode in HoursList)
                            {
                                Hour hour = new Hour();

                                hour.Time = hourNode.Attributes.GetNamedItem("name").InnerText;
                                hour.Teacher = hourNode.SelectSingleNode("Teacher").Attributes.GetNamedItem("name").InnerText;
                                hour.Room = hourNode.SelectSingleNode("Room").Attributes.GetNamedItem("name").InnerText;
                                hour.Subject = hourNode.SelectSingleNode("Subject").Attributes.GetNamedItem("name").InnerText;

                               // day.Hours.Add(hour);
                            }

                           // subgroup.Days.Add(day);
                        }

                        //add to database
                        db.Subgroups.Add(subgroup);
                        await db.SaveChangesAsync();

                    }
                }

            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }


        public async Task AddAllSubgroup()
        {
            try
            {
                XmlNodeList SubgroupList = xmlDoc.DocumentElement.SelectNodes("/Students_Timetable/Subgroup");

                //List<Subgroup> ListSubgroup = new List<Subgroup>();
                int i = 1;
                int j = 1;
                int k = 1;
                foreach (XmlNode groupNode in SubgroupList)
                {
                    Subgroup subgroup = new Subgroup();
                    subgroup.IdSubgroup = i;
                    
                    subgroup.Label = groupNode.Attributes.GetNamedItem("name").InnerText;

                    db.Subgroups.Add(subgroup);
                    await db.SaveChangesAsync();

                    XmlNodeList DaysList = groupNode.SelectNodes("Day");

                    foreach (XmlNode dayNode in DaysList)
                    {
                        Day day = new Day();
                        day.IdDay = j;
                        day.IdSubgroup = i;
                        
                        day.Label = dayNode.Attributes.GetNamedItem("name").InnerText;


                        db.Days.Add(day);
                        await db.SaveChangesAsync();

                        XmlNodeList HoursList = dayNode.SelectNodes("Hour");
                        //day.Subgroup = subgroup;
                        foreach (XmlNode hourNode in HoursList)
                        {
                            if (hourNode.HasChildNodes)
                            {
                                Hour hour = new Hour();
                                hour.IdDay = j;
                                hour.IdHour = k;

                                hour.Time = hourNode.Attributes.GetNamedItem("name").InnerText;


                                hour.Teacher = hourNode.SelectSingleNode("Teacher").Attributes.GetNamedItem("name").InnerText;
                                hour.Room = hourNode.SelectSingleNode("Room").Attributes.GetNamedItem("name").InnerText;
                                hour.Subject = hourNode.SelectSingleNode("Subject").Attributes.GetNamedItem("name").InnerText;
                                hour.Day = day;
                                
                                db.Hours.Add(hour);
                                await db.SaveChangesAsync();

                                //day.Hours.Add(hour);
                                k++;

                            }
                          
                        }
                        
                        //db.Days.Add(day);
                        //await db.SaveChangesAsync();

                        j++;
                        //subgroup.Days.Add(day);

                    }

                    i++;

                   // ListSubgroup.Add(subgroup);
                    //db.Subgroups.Add(subgroup);
                    //await db.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

    }
    
}