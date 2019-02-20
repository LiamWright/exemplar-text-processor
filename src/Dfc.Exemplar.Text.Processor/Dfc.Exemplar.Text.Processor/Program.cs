using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dfc.Exemplar.Text.Processor
{
    class Program
    {
        static void Main(string[] args)
        {

            var csv = new List<string[]>();
            List<CourseTextModel> courses = new List<CourseTextModel>();
            
            var lines = System.IO.File.ReadAllLines(@"InputFileLocationGoesHere");

            for (int i = 1; i < lines.Length; i++)
            {
                var wholeLine = lines[i];
                //TODO, make unicode
                var line = wholeLine.Split('	');
                
                CourseTextModel course = new CourseTextModel
                {
                    id = Guid.NewGuid(),
                    LearnAimRef = line[0],
                    QualificationCourseTitle = line[1],
                    NotionalNVQLevelv2 = line[2],
                    TypeName = line[3],
                    AwardOrgCode = line[4],
                    CountOfOpportunities = line[5],
                    CourseDescription = line[6],
                    EntryRequirements = line[7],
                    WhatYoullLearn = line[8],
                    HowYoullLearn = line[9],
                    WhatYoullNeed = line[10],
                    HowYoullBeAssessed = line[11],
                    WhereNext = line[12]
                };
                courses.Add(course);
            }
            File.WriteAllText(@"InputFileLocationGoesHere", JsonConvert.SerializeObject(courses));

        }
    }
    class CourseTextModel
    {
        public Guid id { get; set; }
        public string LearnAimRef { get; set; }
        public string QualificationCourseTitle { get; set; }
        public string NotionalNVQLevelv2 { get; set; }
        public string TypeName { get; set; }
        public string AwardOrgCode { get; set; }
        public string CountOfOpportunities { get; set; }
        public string CourseDescription { get; set; }
        public string EntryRequirements { get; set; }
        public string WhatYoullLearn { get; set; }
        public string HowYoullLearn { get; set; }
        public string WhatYoullNeed { get; set; }
        public string HowYoullBeAssessed { get; set; }
        public string WhereNext { get; set; }
    }

}
