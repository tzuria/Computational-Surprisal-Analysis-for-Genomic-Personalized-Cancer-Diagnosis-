using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNumerics.LinearAlgebra;
using DotNumerics;
using System.IO;
using System.Data;

namespace FinalProjectPrototype
{
    /// <summary>
    ///Every data that insert to the program will be convering to input data object. 
    /// </summary>
        public class InputData
        {
            private string[] _times;
            private List<string> _genes;
            private double[,] data;


            private int _numOfGenes;
            private int _numOfTimes;

            private double[] _w;
            private double[,] _u;
            private double[,] _vt;
            public double[,] _lagrange;

            public InputData(Stream filestream)
            {
                //check the Pass Stream whether it is readable or not
                if (!filestream.CanRead)
                {
                    return;
                }


                _genes = new List<string>();

                //count lines:
                _numOfGenes = 0;
                List<List<double>> tmpArray = new List<List<double>>();
                List<double> tmpLine = new List<double>();

                string line;
                string[] linearr;


                using (StreamReader lineReader = new StreamReader(filestream))
                {
                    //first line is headers:
                    _times = lineReader.ReadLine().Split(',');
                    _numOfTimes = _times.Length;

                    while ((line = lineReader.ReadLine()) != null)
                    {
                        tmpLine.Clear();

                        //System.Diagnostics.Debug.Write(line+"\n");
                        linearr = line.Split(',');
                        _numOfGenes++;

                        for (int i = 0; i < _numOfTimes; i++)
                        {
                            if (linearr[i] == "null" || linearr[i] == "") 
                                tmpLine.Add(0);
                            else
                                tmpLine.Add(Convert.ToDouble(linearr[i]));
                        }
                        tmpArray.Add(new List<double>(tmpLine));

                    }
                }



                data = new double[_numOfGenes, _numOfTimes];

                tmpArray = removeZeros(tmpArray);

                int lineNumber = 0;
                int cellNumber = 0;
                foreach (List<double> tmpList in tmpArray)
                {
                    foreach (double num in tmpList)
                    {

                        data[lineNumber, cellNumber] = Math.Log(num, Math.E);
                        cellNumber++;

                    }

                    cellNumber = 0;
                    lineNumber++;

                }


                alglib.rmatrixsvd(data, _numOfGenes, _numOfTimes, 1, 1, 0, out _w, out _u, out _vt);


                _lagrange = new double[_w.Length, _w.Length];

                //calculate the lagrange multipliers:
                for (int i = 0; i < _w.Length; i++)
                {
                    for (int j = 0; j < _w.Length; j++)
                    {
                        // _lagrange[i, j] = Math.Round( (_w[i] * _vt[i, j]), 0);
                        _lagrange[i, j] = double.Parse((_w[i] * _vt[i, j]).ToString());


                    }
                }

            }

            private List<List<double>> removeZeros(List<List<double>> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list[i].Count; j++)
                    {
                        if ((list[i])[j] == 0)
                        {
                            list[i][j] = 0.0001;
                        }
                    }
                }
                return list;
            }

            public double[,] getData()
            {
                return data;
            }


            public DataTable getTimesDatatable()
            {
                DataTable dt = new DataTable("times");
                DataRow row;

                dt.Columns.Add(new DataColumn("text", typeof(String)));
                dt.Columns.Add(new DataColumn("value", typeof(int)));


                for (int i = 1; i < _times.Length; i++)
                {
                    row = dt.NewRow();
                    row["text"] = _times[i];
                    row["value"] = i;
                    dt.Rows.Add(row);
                }

                return dt;


            }

            public DataTable getLagrangeDatatable()
            {
                DataTable dt = new DataTable("LAgrange multipliers per phenotype");
                //create columns
                for (int i = 0; i < _times.Length; i++)
                {
                    dt.Columns.Add(new DataColumn(_times[i], typeof(Double)));
                }

                DataRow row;

                for (int i = 0; i < _times.Length; i++)
                {
                    row = dt.NewRow();
                    for (int j = 0; j < _times.Length; j++)
                    {
                        row[_times[j]] = _lagrange[i, j];
                    }

                    dt.Rows.Add(row);
                }


                return dt;
            }

            public DataTable getUMultiplied(int constraint, int time)
            {


                DataTable dt = new DataTable("list of genes and values for phenotype: " + constraint + ", at time: " + _times[time + 1]);
                //dt.Columns.Add(new DataColumn("serial", typeof(int)));
                dt.Columns.Add(new DataColumn("gene", typeof(String)));
                dt.Columns.Add(new DataColumn("value", typeof(Double)));



                // object[,] res = new object[_numOfGenes,2];



                double multiplier = _lagrange[constraint, time];

                for (int i = 0; i < _numOfGenes; i++)
                {
                    DataRow row = dt.NewRow();
                    row[0] = _genes[i];
                    row[1] = _u[i, time] * multiplier;
                    dt.Rows.Add(row);
                    //res[i,0] = _u[i, time] * multiplier;
                    //res[i, 1] = _genes[i];
                }

                // res.OrderByDescending<double>();
                //dt.DefaultView.Sort = ", value DESC";
                //Select("", "value");
                return dt;

            }


            public DataTable getUMultiplied(int constraint)
            {


                DataTable dt = new DataTable("list of genes and values for phenotype: " + constraint);
                //dt.Columns.Add(new DataColumn("serial", typeof(int)));
                dt.Columns.Add(new DataColumn("gene", typeof(String)));
                dt.Columns.Add(new DataColumn("value", typeof(Double)));



                // object[,] res = new object[_numOfGenes,2];



                //double multiplier = _lagrange[constraint, time];

                for (int i = 0; i < _numOfGenes; i++)
                {
                    DataRow row = dt.NewRow();
                    row[0] = _genes[i];
                    row[1] = _u[i, constraint];
                    dt.Rows.Add(row);
                    //res[i,0] = _u[i, time] * multiplier;
                    //res[i, 1] = _genes[i];
                }

                // res.OrderByDescending<double>();
                //dt.DefaultView.Sort = ", value DESC";
                //Select("", "value");
                return dt;

            }






            public DataTable get_U()
            {
                DataTable dt = new DataTable("_U");
                //create columnss
                dt.Columns.Add(new DataColumn("gene name", typeof(String)));
                for (int i = 1; i < _times.Length; i++)
                {
                    dt.Columns.Add(new DataColumn("G" + (i - 1).ToString(), typeof(Double)));
                }

                DataRow row;

                for (int i = 0; i < _numOfGenes; i++)
                {
                    row = dt.NewRow();
                    row["gene name"] = _genes[i];
                    for (int j = 1; j < _times.Length; j++)
                    {
                        row["G" + (j - 1).ToString()] = _u[i, j - 1];
                    }

                    dt.Rows.Add(row);
                }


                return dt;

            }
        
    }
}
