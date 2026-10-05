using System;
using System.IO;
using System.Windows.Forms;

namespace MO32_2_Vasileva_Meleme.NeuroNet
{
    abstract class Layer
    {
        //поля

        protected string name_Layer; //наименования слоев
        string pathDirWaights; // путь к папке с весами
        string pathFileWeights; //путь к файлу с весами
        protected int numofneurons;  // число нейронов текущего слоя
        protected int numofprevneurons; //число нейроно предыдущего слоя
        protected const double learningrate = 0.05; //
        protected const double momentum = 0.5;  //
        protected double[,] lastdeltaweights;   //
        protected Neuron[] neurons; //


        //свойство

        public double[] Data
        {
            set
            {
                for(int i=0; i<numofneurons; i++)
                {
                    neurons[i].Activator(value);
                }
            }
        }

        //конструктор
        protected Layer(int non, int nopn, NeuronType nt, string nm_Layer)
        {
            //
            //
            numofneurons = non; //кол во на тек слое
            numofprevneurons = nopn; //колво на пред слое
            neurons = new Neuron[non];  //определение массива нейронов
            name_Layer = nm_Layer;
            pathDirWaights = AppDomain.CurrentDomain.BaseDirectory + "memory\\"; //папка
            pathFileWeights = pathDirWaights + name_Layer + "_memory.csv";  //путь к файлу в папке

            lastdeltaweights = new double[non, nopn + 1];
            double[,] Weights;    //временный массив синаптических весов
        }

        public double[,] WeightInitialize(MemoryMode mm, string path)
        {
            return new double[1, 1];
        }
if (File.Exisist(pathFileWeights))
    Weights= WeightInitialize(MemoryMode.GET, pathFileWeights);
        else
        {
            Directory.CreateDirectory(pathDirWeights);
            Weights= WeightInitialize(MemoryMode.INIT, pathFileWeights);
        }

        for(int i=0; i<non; i++)
        {
            double[] tmp_weights = new double[nopn +1];
            for (int j=0; j<nopn+1; j++)
            {
                tmp_weights[j]=Weights[i,j];
            }
            neorons[i]=new Neuron(tmp_weights, nt);
        }
    }
}
