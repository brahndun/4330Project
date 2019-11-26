using System;
using System.Collections.Generic;

namespace LoginNavigation
{
    public static class InterestsData
    {
        public static IList<Interests> interests { get; private set; }

        static void InterestData()
        {
            interests = new List<Interests>();

            interests.Add(new Interests
            {
                Subject = "Computer Science",
                SubjectInterests = new String[10] { "Compiler Optimization", "Data Mining", "Graphics and Visualization", "High Performance Computing", "Cyber Security", "Networking", "Bioinformatics", "Artificial Intelligence", "Machine Learning", "Software Engineering" }
            });

            interests.Add(new Interests
            {
                Subject = "Biology",
                SubjectInterests = new String[10] { "Microbiology", "Proteins", "Marine Life", "Biochemistry", "Fungi", "Human Anatomy", "Biophysics", "Pediatric Research", "Pharmacology", "Bioinformatics" }
			});

            interests.Add(new Interests
            {
                Subject = "Chemistry",
                SubjectInterests = new String[10] { "Thermoelectricity", "Catalysis and Catalytic Materials", "Chemical Neuroscience", "Biochemistry", "Atomic Layer Deposition", "Enzymology", "Climate Chemistry", "Battery Science", "Ionic and Covalent Bonds", "Metal Oxides" }
            });

            interests.Add(new Interests
            {
                Subject = "Civil Engineering",
                SubjectInterests = new String[10] { "Construction Materials", "Structural and Computational Mechanics", "Bridge Engineering", "Seismic Engineering", "Structural Dynamics", "Engineering Management", "Fire Structual Engineering", "Informatics", "Concrete", "Hazard Mitigation" }
            });

            interests.Add(new Interests
            {
                Subject = "Mathematics",
                SubjectInterests = new String[10] { "Knot Theory", "Topology", "Differential Geometry", "Fluid Mechanics", "Probability", "Statistics", "Numerical Analysis", "Set Theory", "Logic", "Differential Equations" }
            });
        }
    }
}
    
