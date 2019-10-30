using System;
using System.Collections.Generic;
using System.Text;

namespace HeritageWalksAPI.Model
{
    class Trail
    {
        private int id;
        private string name;
        private string desciption;
        private double time;
        private double length;
        private string img;
        private string audio;
        private DateTime created_at;
        private DateTime updated_at;

        public Trail(int ID, string Name, string Desc, double Time, double Length, DateTime created, DateTime updated, string Image, string Audio)
        {
            this.id = ID;
            this.name = Name;
            this.desciption = Desc;
            this.time = Time;
            this.length = Length;
            this.img = Image;
            this.audio = Audio;
            this.created_at = created;
            this.updated_at = updated;
        }

        //getters && setters
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Desc
        {
            get { return desciption; }
            set { desciption = value; }
        }

        public double Time
        {
            get { return time; }
            set { time = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public string Image
        {
            get { return img; }
            set { img = value; }
        }

        public string Audio
        {
            get { return audio; }
            set { audio = value; }
        }

        public DateTime CreatedAt
        {
            get { return created_at; }
            set { created_at = value; }
        }

        public DateTime UpdatedAt
        {
            get { return updated_at; }
            set { updated_at = value; }
        }
    }
}
