using SoNLAE_solving_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server
{
    class CalculationLogic
    {
        private int startLineIndex;
        private int endLineIndex;

        private int addVectorIndex;
        private VectorInterface<Double>[] vectors;

        private RestDTO restDTO;

        public CalculationLogic(RestDTO restDTO)
        {
            this.restDTO = restDTO;

            this.startLineIndex = restDTO.StartLineIndex;
            this.endLineIndex = restDTO.EndLineIndex;
            this.addVectorIndex = restDTO.AddVectorIndex;
            this.vectors = restDTO.Vectors;

        }

        public RestDTO Run()
        {
            int i = addVectorIndex;
            Double diagonalElement = vectors[i][i];

            if (Double.IsInfinity(1 / diagonalElement)
                    || Double.IsNaN(1 / diagonalElement))
                return restDTO;

            for (int j = startLineIndex; j < endLineIndex && j < vectors.Length; j++)
            {
                VectorInterface<Double> lineToAdd = vectors[i].Copy();
                Double coefficient = -vectors[j][i] / diagonalElement;

                lineToAdd.Mul(coefficient);
                vectors[j].Add(lineToAdd);
            }

            return restDTO;
        }
    }
}
