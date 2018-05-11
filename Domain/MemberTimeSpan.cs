using System;

namespace Publications
{
    public class MemberTimeSpan
    {
        public MemberTimeSpan(string name, TimeSpan lengthOnProject)
        {
            Name = name;
            LengthOnProject = lengthOnProject;
        }
        // public MemberTimeSpan()
        // {

        // }
        public string Name { get; set; }
        public TimeSpan LengthOnProject { get; set; }

    }
}
