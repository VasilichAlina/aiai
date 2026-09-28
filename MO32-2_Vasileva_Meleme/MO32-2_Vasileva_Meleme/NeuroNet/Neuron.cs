using System;
using static System.Math;

namespace MO32_2_Vasileva_Meleme.NeuroNet
{
    class Neuron
    {
        private double[] inputs; //входы
        private double[] weights; //vвеса
        private double output; // выход
        private double derivative; // производная функция активации
        private NeuronType type;

        //константа для функции активации релу
        private double a = 0.01d;

        //свойства
        public double[] Weights { get => weights; set => weights = value; }
        public double[] Inputs { get => inputs; set => inputs = value;}
        public double Output { get => output; }
        public double Derivative { get => derivative; }

        //конструктор
        public Neuron(double[] memoryWeights, NeuronType typeNeuron)
        {
            type = typeNeuron;
            weights = memoryWeights;
        }

        public void Activator(double[] i)
        {
            inputs = i;

            double sum = weights[0];

            for(int j=0; j<inputs.Length; j++)
            {
                sum += inputs[j] * weights[j + 1];

            }

            switch (type)
            {
                case NeuronType.Hidden:
                    output = LeakyReLU(sum);
                    derivative = LeakyReLU_Derivativator(sum);
                    break;

                case NeuronType.Output:
                    output= Exp(sum);
                    break;
            }
        }
        private double LeakyReLU(double x)
        {
            if (x >= 0)
            {
                return x;
            }
            else
            {
                return a * x;
            }
        }

        // Производная функции активации LeakyReLU
        private double LeakyReLU_Derivativator(double x)
        {
            if (x >= 0)
            {
                return 1.0d;
            }
            else
            {
                return a;
            }
        }
    }
}
