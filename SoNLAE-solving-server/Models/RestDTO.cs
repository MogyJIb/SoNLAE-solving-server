using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server.Models
{

    public class RestDTO
    {
        public int StartLineIndex { get; set; }
        public int EndLineIndex { get; set; }

        public int AddVectorIndex { get; set; }
        public DoubleVector[] Vectors { get; set; }

        public RestDTO(int startLineIndex, int endLineIndex, int addVectorIndex, DoubleVector[] vectors)
        {
            StartLineIndex = startLineIndex;
            EndLineIndex = endLineIndex;
            AddVectorIndex = addVectorIndex;
            Vectors = vectors;
        }

        public static string Serialize(RestDTO restDTO)
        {
            string result = JsonConvert.SerializeObject(restDTO);
            return result;
        }

        public static RestDTO Deserialize(string data)
        {
            RestDTO restDTO = JsonConvert.DeserializeObject<RestDTO>(data);
            return restDTO;
        }

        public override bool Equals(object obj)
        {
            var dTO = obj as RestDTO;
            return dTO != null &&
                   StartLineIndex == dTO.StartLineIndex &&
                   EndLineIndex == dTO.EndLineIndex &&
                   AddVectorIndex == dTO.AddVectorIndex &&
                   Vectors.ToList().Equals(dTO.Vectors.ToList());
        }

        public override int GetHashCode()
        {
            var hashCode = 1286356451;
            hashCode = hashCode * -1521134295 + StartLineIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + EndLineIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + AddVectorIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<DoubleVector[]>.Default.GetHashCode(Vectors);
            return hashCode;
        }
    }
}
