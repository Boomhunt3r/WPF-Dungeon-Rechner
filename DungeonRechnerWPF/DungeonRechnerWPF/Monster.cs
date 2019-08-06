using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRechnerWPF
{
    public class Monster : INotifyPropertyChanged
    {
        public string FileName
        {
            get
            {
                string tempName = $"{m_Name}.xml";
                char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

                foreach (char invalid in invalidChars)
                {
                    tempName = tempName.Replace(invalid.ToString(), "");
                }

                return tempName;
            }
        }

        private string m_Name;
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
                OnPropertyChanged();
            }
        }

        private int m_Health;
        public int Health
        {
            get
            {
                return m_Health;
            }
            set
            {
                m_Health = value;
                OnPropertyChanged();
            }
        }

        private int m_Defense;
        public int Defense
        {
           get
            {
                return m_Defense;
            }
            set
            {
                m_Defense = value;
                OnPropertyChanged();
            }
        }

        private int m_Armor;
        public int Armor
        {
            get
            {
                return m_Armor;
            }
            set
            {
                m_Armor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Helfer-Methode zum aufrufen des change events.
        /// CallerMemberName sagt dem Compiler, dass er die Variable mit dem Namen des aufrufenden Members füllen soll.
        /// </summary>
        /// <param name="_propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string _propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
