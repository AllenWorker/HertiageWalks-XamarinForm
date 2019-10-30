using System;
using System.Collections.Generic;
using System.Text;

namespace HeritageWalksAPI.Model
{
    class Stop
    {
        private int id;
        private string name;
        private string streetlocation;
        private string short_desc;
        private string long_desc;
        private double x;
        private double y;
        private string image;
        private string audio;
        private DateTime created_at;
        private DateTime updated_at;

        public Stop(int ID, string Name, string StreetLocation, string Short_Desc, string Long_Desc, double x, double y, DateTime created, DateTime updated, string Image, string Audio)
        {
            this.id = ID;
            this.name = Name;
            this.streetlocation = StreetLocation;
            this.short_desc = Short_Desc;
            this.long_desc = Long_Desc;
            this.X = x;
            this.Y = y;
            this.image = Image;
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

        public string StreetLocation
        {
            get { return streetlocation; }
            set { streetlocation = value; }
        }

        public string ShortDesc
        {
            get { return short_desc; }
            set { short_desc = value; }
        }

        public string LongDesc
        {
            get { return long_desc; }
            set { short_desc = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
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
