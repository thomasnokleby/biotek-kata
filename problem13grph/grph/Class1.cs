using System;
using System.Collections.Generic;
using System.Text;

namespace grph
{
    public class Class1
    {
        public string findOverlapGraph(string filename) 
        {
            var nodes = LoadFasta(filename);
            List<GraphEdge> overlapGraph = new List<GraphEdge>();

            foreach (var node in nodes)             
            {
                foreach (var innernode in nodes) 
                {
                    int sequencelength = innernode.DNASequence.Length;

                    if (node == innernode) 
                    {
                        continue;
                    }
                    if (node.DNASequence.EndsWith(innernode.DNASequence.Substring(0,3))) 
                    {
                        //Match!
                        overlapGraph.Add(new GraphEdge
                        {
                            StartNodeName = node.Label.Replace(">",""),
                            EndNodeName = innernode.Label.Replace(">","")
                        });
                    }
                }
            }
            return graphToString(overlapGraph);
        }

        private string graphToString(List<GraphEdge> graph) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var edge in graph) 
            {
                sb.AppendLine(edge.StartNodeName + " " + edge.EndNodeName);
            }
            return sb.ToString();
        }


        private List<p10CONS.LabeledDNASequence> LoadFasta(string filename)
        {
            var result = p10CONS.FASTALoader.loadFASTA(filename);
            return result;
        }

        public class GraphEdge 
        {
            public string StartNodeName { get; set; }    
            public string EndNodeName { get; set; }        
        }

    }
}
