using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO
    {
        private string manv;
        private string honv;
        private string tennv;
        private DateTime ngaysinh;
        private string sdt;
        private string macv;
        private int soca;
        private int thuong;
        private DateTime ngaytuyendung;
        private string htcongviec;

        public string MaNV { get => manv; set => manv = value; }
        public string HoNV { get => honv; set => honv = value; }
        public string TenNV { get => tennv; set => tennv = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string MaCV { get => macv; set => macv = value; }
        public int Soca { get => soca; set => soca = value; }
        public int Thuong { get => thuong; set => thuong = value; }
        public DateTime NgayTuyenDung { get => ngaytuyendung; set => ngaytuyendung = value; }
        public string HTcongviec { get => htcongviec; set => htcongviec = value; }

        public EmployeeDTO() { }

        public EmployeeDTO(string manv)
        {
            this.manv = manv;
        }

        public EmployeeDTO(string manv, string sdt, string macv, string tennv)
        {
            this.manv = manv;
            this.sdt = sdt;
            this.macv = macv;
            this.tennv = tennv;
        }

        public EmployeeDTO(string manv, string honv, string tennv, DateTime ngaysinh, string sdt, string macv, int soca, int thuong, DateTime ngaytuyendung, string htcongviec)
        {
            this.manv = manv;
            this.honv = honv;
            this.tennv = tennv;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.macv = macv;
            this.soca = soca;
            this.thuong = thuong;
            this.ngaytuyendung = ngaytuyendung;
            this.htcongviec = htcongviec;
        }
    }
}
