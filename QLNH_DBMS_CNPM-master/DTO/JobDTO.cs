using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JobDTO
    {
        private string maCV;
        private string tenCV;
        private float luong;

        public JobDTO()
        {
        }

        public JobDTO(string maCV, string tenCV, float luong)
        {
            MaCV = maCV;
            TenCV = tenCV;
            Luong = luong;
        }

        public string MaCV { get => maCV; set => maCV = value; }
        public string TenCV { get => tenCV; set => tenCV = value; }
        public float Luong { get => luong; set => luong = value; }
    }
}
