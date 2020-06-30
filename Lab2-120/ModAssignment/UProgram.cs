using System;
using System.Collections.Generic;
using System.Text;

namespace ModAssignment
{
    class UProgram
    {
        string ProgramName { get; set; }
        Degree[] Degree { get; set; }

        public UProgram(string name)
        {
            this.ProgramName = name;
            this.Degree = new Degree[5];
        }

        public string Name()
        {
            return this.ProgramName;
        }

        public string Degrees()
        {
            string allDegrees = "";
            for (int i = 0; i < this.Degree.Length; i++)
            {
                if (this.Degree[i] != null)
                {
                    allDegrees = allDegrees + this.Degree[i].Name() + ", ";
                }
            }
            return allDegrees;
        }

        public void AddDegree(Degree degree)
        {
            for (int i = 0; i < this.Degree.Length; i++)
            {
                if (this.Degree[i] == null)
                {
                    this.Degree[i] = degree;
                    break;
                }
            }
        }
    }
}
