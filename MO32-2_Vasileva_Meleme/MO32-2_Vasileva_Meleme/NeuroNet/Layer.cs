using System;
using System.IO;
using System.Windows.Forms;

namespace MO32_2_Vasileva_Meleme.NeuroNet
{
    abstract class Layer
    {
        //поля

        protected string name_Layer; //наименования слоев
        string pathDirWeights; // путь к папке с весами
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
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\"; //папка
            pathFileWeights = pathDirWeights + name_Layer + "_memory.csv";  //путь к файлу в папке

            lastdeltaweights = new double[non, nopn + 1];
            double[,] Weights;    //временный массив синаптических весов

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }

            for (int i = 0; i < non; i++)
            {
                double[] tmp_weights = new double[nopn + 1];
                for (int j = 0; j < nopn + 1; j++)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                neurons[i] = new Neuron(tmp_weights, nt);
            }
        
    }


        public double[,] WeightInitialize(MemoryMode mm, string path)
        {
            char[] delim = new char[] { ';', ' ' }; //
            string tmpStr;  //
            string[] tmpStrWeights;
            double[,] weights = new double[numofneurons, numofprevneurons + 1];

            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(path);
                    string[] memory_element;
                    for(int i=0; i<numofneurons;i++)
                    {
                        memory_element = tmpStrWeights[i].Split(delim);
                        for (int j = 0; j < numofprevneurons + 1; j++)
                            {
                            weights[i, j] = double.Parse(memory_element[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                             }
                    }
                    break;
                case MemoryMode.SET:
                    tmpStrWeights = new string[numofneurons];

                    if(!File.Exists(path))
                    {
                        MessageBox.Show("!!! В Н И М А Н И Е!!!\n Файл"+name_Layer+
                            "_memory.csv синаптических весов"+"\nНЕ НАЙДЕН!!! \n После нажатия кнопки ОК " +
                            "создастся соответствующий файл, и все синаптические веса будут сохранены в нем",     
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    for(int i=0; i<numofneurons;i++)
                    {
                        tmpStr = neurons[i].Weights[0].ToString();
                        for(int j=0; j<numofprevneurons+1; j++)
                        {
                            tmpStr += delim[0] + neurons[i].Weights[j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.WriteAllLines(path, tmpStrWeights);
                    break;
                case MemoryMode.INIT:

                    MessageBox.Show("!!! В Н И М А Н И Е!!!\n Файл" + name_Layer +
                             "_memory.csv синаптических весов" + "\nНЕ НАЙДЕН!!! \n После нажатия кнопки ОК " +
                             "создастся соответствующий файл, "+
                             "нейросеть вернется к исходному состоянию <новорожденности>, и потребуется обучать ее заново",
                             "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    Random random = new Random();
                    double tmpRatio;
                    double tmpShift;
                    double[] tmpArr = new double[numofprevneurons + 1];
                    tmpStrWeights = new string[numofneurons];

                    for(int i=0; i<numofneurons;i++)
                    {
                        for (int j=0; j<numofprevneurons+1;j++)
                    }

                    break;
                default:
                    break;
            }
            return new double[1, 1];
        }
    }
}
