using System;
using System.Collections.Generic;

namespace LoginNavigation
{
    public static class InterestsData
    {
        public static IList<Interest> Interests { get; private set; }

        static InterestsData()
        {
            Interests = new List<Interest>();

            Interests.Add(new Interest
            {
                Subject = "Computer Science",
                SubjectInterests = new string[10] { "Compiler Optimization", "Data Mining", "Graphics and Visualization", "High Performance Computing", "Cyber Security", "Networking", "Bioinformatics", "Artificial Intelligence", "Machine Learning", "Software Engineering" }
            });

            Interests.Add(new Interest
            {
                Subject = "Biology",
                SubjectInterests = new string[10] { "Microbiology", "Proteins", "Marine Life", "Biochemistry", "Fungi", "Human Anatomy", "Biophysics", "Pediatric Research", "Pharmacology", "Bioinformatics" }
			});

            Interests.Add(new Interest
            {
                Subject = "Chemistry",
                SubjectInterests = new string[10] { "Thermoelectricity", "Catalysis and Catalytic Materials", "Chemical Neuroscience", "Biochemistry", "Atomic Layer Deposition", "Enzymology", "Climate Chemistry", "Battery Science", "Ionic and Covalent Bonds", "Metal Oxides" }
            });

            Interests.Add(new Interest
            {
                Subject = "Civil Engineering",
                SubjectInterests = new string[10] { "Construction Materials", "Structural and Computational Mechanics", "Bridge Engineering", "Seismic Engineering", "Structural Dynamics", "Engineering Management", "Fire Structual Engineering", "Informatics", "Concrete", "Hazard Mitigation" }
            });

            Interests.Add(new Interest
            {
                Subject = "Mathematics",
                SubjectInterests = new string[10] { "Knot Theory", "Topology", "Differential Geometry", "Fluid Mechanics", "Probability", "Statistics", "Numerical Analysis", "Set Theory", "Logic", "Differential Equations" }
            });
        }
    }
}
    
