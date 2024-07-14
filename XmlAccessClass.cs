using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Plug_and_Play
{
    internal class XmlAccessClass
    {
        XmlDocument xmlDosya;
        public XmlAccessClass()
        {
            try
            {
                string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
                xmlDosya = new XmlDocument();
                xmlDosya.Load(bugun);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xml bugünün döviz kurlarını çekerken hata ile karşılaştı, hata :\n"+ ex.Message);
            }
            
        }

        public string BanknoteBuying(string code)
        {
            string result = $"error code : BanknoteBuying{code}";
            try
            {
                result = xmlDosya.SelectSingleNode($"Tarih_Date/Currency[@Kod='{code}']/BanknoteBuying").InnerXml;
                Console.WriteLine($"result değişkeni içine  ({code}) BanknoteBuying işlemi başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"result değişkeni içine  ({code}) BanknoteBuying işlemi gerçekleştirilirken hata alındı, hata : \n" + ex.Message);
            }
            return result;
        }

        public string BanknoteSelling(string code)
        {
            string result  = $"error code : BanknoteSelling{code}";
            try
            {
                result = xmlDosya.SelectSingleNode($"Tarih_Date/Currency[@Kod='{code}']/BanknoteSelling").InnerXml;
                Console.WriteLine($"result değişkeni içine  ({code}) BanknoteSelling işlemi başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"result değişkeni içine  ({code}) BanknoteSelling işlemi gerçekleştirilirken hata alındı, hata : \n" + ex.Message);
            }
            return result;
        }


    }
}
