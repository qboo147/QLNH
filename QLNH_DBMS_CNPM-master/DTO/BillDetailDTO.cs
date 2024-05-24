using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDetailDTO
    {
        private int maHD;
        private string maSP;
        private string tenSP;
        private int soLuong;
        private double donGia;
        private double tongGT;
        private int? maChiTietHD;

        public int MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public double TongGT { get => tongGT; set => tongGT = value; }
        public int? MaChiTietHD { get => maChiTietHD; set => maChiTietHD = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }

        public BillDetailDTO() { }
        public BillDetailDTO(int maHD, string maSP, string tenSP, int soLuong, double donGia, double tongGT, int? machitiethd)
        {
            MaHD = maHD;
            MaSP = maSP;
            TenSP = tenSP;  
            SoLuong = soLuong;
            DonGia = donGia;
            TongGT = tongGT;
            
            MaChiTietHD = machitiethd;
        }
    }
}
