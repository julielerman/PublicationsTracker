using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publications
{
    #if false
    class OriginalProgram
    {
        static void OriginalMain(string[] args)
        {
            //LazyLoadMembers();
            // LazyLoadPostsWithoutProxy();
            //SimpleGroupByTranslation();
            //CreateMemberWithCommuteTime();
            // GetMemberWithCommuteTime();
            //GetTeamMemberCountViaView();
            //GetCommuteTimeViaDefiningQuery();
            ReturnRandomTypeFromRawSql();
        }

        private static void GetCommuteTimeViaDefiningQuery()
        {
            using (var context = new PublicationsContext())
            {
                
           
                var commutes = context.Query<TeamCommute>().ToList();
            }
        }
        private static void ReturnRandomTypeFromRawSql()
        {
           //NOTE: if query<teamcommute> is already defined in context as a defining query,
           //you can't ALSO use it with FromSql 
            using (var context = new PublicationsContext())
            {

             
               // var teamlist=context.Query<TeamCommute>().FromSql("select Name,TypicalCommuteTime from TeamMembers").ToList();
                var teamlist = context.Query<TeamCommute>().FromSql("EXEC GetCommuteTimes {0}",101).ToList();

            }
        }


        private static void GetTeamMemberCountViaView()
        {
            using (var context = new PublicationsContext())
            {
                var teamcount=context.TeamMemberCounts.ToList();
            }
        }

        private static void GetMemberWithCommuteTime()
        {
            using (var context = new PublicationsContext())
            {
                var efteam=context.TeamMembers.Where(m => m.TeamId == 101).ToList();
            
            }
        }

        private static void CreateMemberWithCommuteTime()
        {
            var member = new TeamMember { Name = "Arthur Vickers",TeamId=101 };
            member.CalculateCommuteTime(DateTime.Now, DateTime.Now.AddMinutes(128));
            using (var context = new PublicationsContext())
            {
                context.TeamMembers.Add(member);
                context.SaveChanges();
            }
        }


        private static void SimpleGroupByTranslation()
        {
            using (var context = new PublicationsContext())
            {
                var membersGroup = context.TeamMembers.GroupBy(m => m.TeamId).Select(g =>new { TeamId = g.Key, Count = g.Count() }).ToList();
                
                    }
        }

        private static void LazyLoadMembers()
        {
           
            using (var context=new PublicationsContext())
            {
                var team = context.Teams.Find(101);
                var memberCount = team.Members.Count();
            }
        }
        private static void LazyLoadPostsWithoutProxy()
        {

            using (var context = new PublicationsContext())
            {
                var blog = context.Blogs.Find(1);
                var memberCount = blog.Posts.Count();
            }
        }
        
    }
    #endif
}
