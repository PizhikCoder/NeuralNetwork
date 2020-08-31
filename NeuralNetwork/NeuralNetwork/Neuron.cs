﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        public Neuron(int InputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();
            for (int i = 0; i < InputCount ; i++)
            {
                Weights.Add(1);
            }
        }
        public double FeedForward(List<double> inputs)
        {
            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            if (NeuronType != NeuronType.Input)
            {
            Output = Sigmoid(sum);
            }
            else
            {
                Output = sum;
            }
            return Output; 
        }
        private double Sigmoid(double x)
        {
            var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
            return result;
        }
        public void SetWeights(params double[] weights)
        {
            //TODO: удалить добавления взиожности обучения сети.
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
