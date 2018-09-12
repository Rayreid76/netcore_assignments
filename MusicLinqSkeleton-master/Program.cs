using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            //var MountName = from p in Artists where p.Hometown == "Mount Vernon" select new {p.ArtistName};
            string[] MountName = Artists.Where(n => n.Hometown == "Mount Vernon").Select( n => new {n.ArtistName, n.Age}.ToString()).ToArray();


            //Who is the youngest artist in our collection of artists?
            
            var YoungArtist = Artists.Min(n => n.Age);


            //Display all artists with 'William' somewhere in their real name
            var SameName = Artists.Where(name => name.ArtistName == "William");
            

            //Display the 3 oldest artist from Atlanta
            string[] oldGuys = Artists.Join(Groups,
                 (n => n.GroupId),
                 (a => a.Id),
                 (joinedArtist, joinedGroup) =>
                 {return $"{joinedArtist.ArtistName}, {joinedGroup.GroupName}";
                 }).ToArray();
            
            var guyAtlanta = Artists.Where(h => h.Hometown == "Atlanta").OrderByDescending(h => h.Age);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	    Console.WriteLine(Groups.Count);
        Console.WriteLine(Artists.Count);
        Console.WriteLine("*******************************");

        Console.WriteLine("*******************************");
        
        Console.WriteLine("##################################################################");
        
        
        }
    }
}
