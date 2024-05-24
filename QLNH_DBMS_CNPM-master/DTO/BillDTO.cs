using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        private int? maHD;
        private string maKH;
        private string trangThai;
        private double giatriHD;
        private string maNVPV;
        private string maBan;
        private string pttt;
        private DateTime ngay;
        private string gio;

        public BillDTO() { }    
        

        public int? MaHD { get => maHD; set => maHD = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public double GiatriHD { get => giatriHD; set => giatriHD = value; }
        public string MaNVPV { get => maNVPV; set => maNVPV = value; }
        public string MaBan { get => maBan; set => maBan = value; }
        public string Pttt { get => pttt; set => pttt = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public string Gio { get => gio; set => gio = value; }

        public BillDTO(int? maHD, string maKH, string trangThai, double giatriHD, string maNVPV, string maBan, string pttt, DateTime ngay, string gio)
        {
            MaHD = maHD;
            MaKH = maKH;
            TrangThai = trangThai;
            GiatriHD = giatriHD;
            MaNVPV = maNVPV;
            MaBan = maBan;
            Pttt = pttt;
            Ngay = ngay;
            MaHD = maHD;
            MaKH = maKH;
            TrangThai = trangThai;
            GiatriHD = giatriHD;
            MaNVPV = maNVPV;
            MaBan = maBan;
            Pttt = pttt;
            Ngay = ngay;
            Gio = gio;
        }
        public BillDTO(string maKH, string trangThai, double giatriHD, string maNVPV, string maBan, string pttt, DateTime ngay, string gio)
        {
            MaKH = maKH;
            TrangThai = trangThai;
            GiatriHD = giatriHD;
            MaNVPV = maNVPV;
            MaBan = maBan;
            Pttt = pttt;
            Ngay = ngay;
            MaHD = maHD;
            MaKH = maKH;
            TrangThai = trangThai;
            GiatriHD = giatriHD;
            MaNVPV = maNVPV;
            MaBan = maBan;
            Pttt = pttt;
            Ngay = ngay;
            Gio = gio;
        }
    }
}
