using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Plug_and_Play
{
    internal class DataAccessClass
    {
        private static readonly string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\database\\dbBuroKilitli.accdb;Jet OLEDB:Database Password=z2X2a212GYemP8Di";
        // z2X2a212GYemP8Di
        public DataAccessClass()
        {
            try
            {
                OleDbConnection testCon = new OleDbConnection(conStr);
                testCon.Open();
                testCon.Close();
                Console.WriteLine("SQL Bağlantısı başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL bağlantısı sırasında hata alındı, hata : \n" + ex.Message);
            }   
        }
        // TableNames
        // tblCase
        // tblHistory
        // tblStaff
        // tblAuth

        ///<summary>
        ///DataGridView içerisine seçili tablonun bütün alanlarının çekilmesini sağlar
        ///</summary>
        public void PrintDgv(string TableName, DataGridView TargetDGV)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = String.Format("Select * from {0}",TableName);
                    
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    TargetDGV.DataSource = dt;
                }
                Console.WriteLine($"DataGridView ({TargetDGV.Name}) nesnesi içine Sql tablosunu ({TableName}) yazma işlemi başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DataGridView ({TargetDGV.Name}) nesnesi içine Sql tablosunu ({TableName}) yazma sırasında hata alındı, hata : \n" + ex.Message, "PrintDgv Hatası");
            }
        }

        ///<summary>
        ///DataGridView içerisine seçili tablodan 2 adet alan çekilmesini sağlar
        ///</summary>
        public void PrintDgv(string TableName, DataGridView TargetDGV, string filed1, string field2)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    // SELECT KullaniciAdi, Eposta from tblStaff
                    cmd.CommandText = String.Format("Select {1}, {2} from {0}", TableName, filed1, field2);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    TargetDGV.DataSource = dt;
                }
                Console.WriteLine($"DataGridView ({TargetDGV.Name}) nesnesi içine Sql tablosunu ({TableName}) yazma işlemi başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DataGridView ({TargetDGV.Name}) nesnesi içine Sql tablosunu ({TableName}) yazma sırasında hata alındı, hata : \n" + ex.Message, "PrintDgv Hatası");
            }
        }

        ///<summary>
        ///DataGridView içerisine seçili tablodan 3 adet alan çekilmesini sağlar
        ///</summary>
        public void PrintDgv(string TableName, DataGridView TargetDGV, string filed1, string field2, string field3)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    // SELECT KullaniciAdi, Eposta from tblStaff
                    cmd.CommandText = String.Format("Select {1}, {2}, {3} from {0}", TableName, filed1, field2, field3);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    TargetDGV.DataSource = dt;
                }
                Console.WriteLine($"DataGridView ({TargetDGV.Name}) nesnesi içine Sql tablosunu ({TableName}) yazma işlemi başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DataGridView ({TargetDGV.Name}) nesnesi içine Sql tablosunu ({TableName}) yazma sırasında hata alındı, hata : \n" + ex.Message, "PrintDgv Hatası");
            }
        }


        ///<summary>
        ///[tblCase] içinden belirli kodun değerini getirir
        ///</summary>
        public double GetValue(string code)
        {
            double result = 0;
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select TRY from tblCase where ID = 1
                    cmd.CommandText = String.Format("Select {1} from {0} where ID = 1", "tblCase", code);
                    con.Open();
                    result = Convert.ToDouble(cmd.ExecuteScalar());
                    con.Close();
                }
                Console.WriteLine($"({code}) kodunda GetValue işlemi başarılı oldu");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"({code}) kodunda GetValue işlemi başarısız oldu, hata : \n" + ex.Message , "GetValue Hatası");
            }
            return result;
        }

        ///<summary>
        ///[tblCase] içinden belirli kodun değerini günceller
        ///</summary>
        public void UpdateValue(string code, double newValue)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //update Personeller set Adi = 'Nancy' where PersonelID = 1
                    cmd.CommandText = String.Format("Update {0} set {1} = {2} where ID = 1", "tblCase", code, newValue.ToString().Replace(',','.'));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"({code}) kodunda UpdateValue işlemi başarılı oldu");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"({code}) kodunda ({newValue}) değeri atama işlemi başarısız oldu, hata : \n" + ex.Message, "UpdateValue Hatası");
            }
            
        }

        ///<summary>
        ///Yeni kullanıcının epostasını kontrol etmek için veritabanına emailine bağlı referans ve pini kaydet
        ///</summary>
        public void NewUserAuth(string _email, string _referance, string _pin)
        {// Yeni kullanıcının epostasını kontrol etmek için veritabanına emailine bağlı referans ve pini kaydet
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //"INSERT INTO tblStudents (ogrAd, ogrNo, ogrEposta) VALUES (P1, P2, P3)"
                    cmd.CommandText = "Insert Into tblAuth (Eposta, Referans, Pin) Values (@P1, @P2, @P3)";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _email;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _referance;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = _pin;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"({_email}) epostasına ({_referance}) referanslı pin (tblAuth) tablosuna yazma işlemi başarılı oldu");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"({_email}) epostasına ({_referance}) referanslı pin (tblAuth) tablosuna yazma işlemi başarısız oldu, hata : \n" + ex.Message, "NewUserAuth(void) Hatası");
            }
        }

        ///<summary>
        ///[tblAuth] tablosu içinde Referans ve Pin aynı kayıt içinde uyuyorsa 'true' değeri döndür
        ///</summary>
        public bool NewUserAuth(string _Referance, string _pin)
        {// Referans ve Pin uyuyorsa 'true' değeri döndür
            try
            {
                string refferedPin = "-1";
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select Pin from tblAuth where Referans = @P1";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _Referance;

                    con.Open();
                    refferedPin = cmd.ExecuteScalar().ToString();
                    con.Close();
                }

                if (_pin == refferedPin)
                {
                    Console.WriteLine($"(tblAuth) içerisinde ({_Referance}) referansına ait pin okuma işlemi başarılı oldu");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblAuth) içerisinde ({_Referance}) referansına ait pin okuma işlemi başarısız oldu, hata : \n" + ex.Message, "NewUserAuth(Bool) Hatası");
            }

            return false;
        }

        ///<summary>
        ///Kayıtlı kullanıcılar arasında uyuşan email var mı kontrol et
        ///</summary>
        public bool CheckEmail(string _email)
        {// Kayıtlı kullanıcılar arasında uyuşan email var mı kontrol et
            try
            {
                int emailCount = -1;
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select count(*) from tblStaff where Eposta = @P1";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _email;

                    con.Open();
                    emailCount = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

                if (emailCount == 0)
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_email}) bulunmamaktadır, email kontrol işlemi başarılı oldu");
                    return true;
                }
                else
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_email}) bulunmaktadır, email kontrol işlemi başarılı oldu");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff) içerisinde ({_email}) bulunmamaktadır, email sayma işlemi başarısız oldu, hata : \n" + ex.Message, "CheckEmail(Bool) Hatası");
            }
            return false;
        }

        ///<summary>
        ///Kayıtlı kullanıcılar arasında uyuşan Kullanıcıadı var mı kontrol et, bu metodu [UserExist] metodundan ayıran özellik [kullanıcıAdı == 0] durumunda true döndürür
        ///</summary>
        public bool CheckUsername(string _username)
        {// Kayıtlı kullanıcılar arasında uyuşan Kullanıcıadı var mı kontrol et
            try
            {
                int usernameCount = -1;
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select count(*) from tblStaff where KullaniciAdi = @P1";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username;

                    con.Open();
                    usernameCount = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

                if (usernameCount == 0)
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) bulunmamaktadır, kullanıcıAdı kontrol işlemi başarılı oldu");
                    return true;
                }
                else
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) bulunmaktadır, kullanıcıAdı kontrol işlemi başarılı oldu");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff) içerisinde ({_username}) bulunmamaktadır, kullanıcıAdı kontrol işlemi başarısız oldu, hata : \n" + ex.Message, "CheckUsername(Bool) Hatası");
            }
            return false;
        }

        ///<summary>
        /// Kayıtlı kullanıcılar arasında uyuşan Kullanıcıadı var mı kontrol et, bu metodu [CheckUsername] metodundan ayıran özellik [kullanıcıAdı > 0] durumunda true döndürür
        ///</summary>
        public bool UserExist(string _username)
        {// Kayıtlı kullanıcılar arasında uyuşan Kullanıcıadı var mı kontrol et
            try
            {
                int usernameCount = -1;
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select count(*) from tblStaff where KullaniciAdi = @P1";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username;

                    con.Open();
                    usernameCount = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

                if (usernameCount == 0)
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) bulunmamaktadır, kullanıcıAdı kontrol işlemi başarılı oldu");
                    return false;
                }
                else
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) bulunmaktadır, kullanıcıAdı kontrol işlemi başarılı oldu");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff) içerisinde ({_username}) bulunmamaktadır, kullanıcıAdı kontrol işlemi başarısız oldu, hata : \n" + ex.Message, "CheckUsername(Bool) Hatası");
            }
            return false;
        }

        ///<summary>
        ///Yeni kullanıcıyı epsota, kullanıcıAdı ve şifre girerek oluştur, pin ve referans alanları şifresini değiştirmek isteyen kullanıcılar için vardır
        ///</summary>
        public void CreateUser(string _username, string _email, string _password)
        {// Yeni kullanıcıyı epsota, kullanıcıAdı ve şifre girerek oluştur, pin ve referans alanları şifresini değiştirmek isteyen kullanıcılar için vardır
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //"INSERT INTO tblStudents (ogrAd, ogrNo, ogrEposta) VALUES (P1, P2, P3)"
                    cmd.CommandText = "Insert Into tblStaff (KullaniciAdi, Eposta, Parola) Values (@P1, @P2, @P3)";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _email;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = _password;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"(tblStaff) içerisinde yeni kullanıcı oluşturma işlemi başarılı oldu");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff) içerisinde yeni kullanıcı oluşturma işlemi başarısız oldu, hata : \n" + ex.Message, "CreateUser(void) Hatası");
            }
        }

        ///<summary>
        ///Aynı username ve email'in uyuştuğundan emin ol, eğer kullanıcı varsa true döndür
        ///</summary>
        public bool CheckUsernameEmail(string _username, string _email)
        {// Aynı username ve email'in uyuştuğundan emin ol, eğer kullanıcı varsa true döndür
            try
            {
                int result = -1;
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "select count(*) from tblStaff where KullaniciAdi = @P1 AND Eposta = @P2";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _email;

                    con.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

                if (result == 1)
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) kullanıcı adına ve ({_email}) epostasına ait kullanıcı bulundu, CheckUsernameEmail işlemi başarılı");
                    return true;
                }
                else
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) kullanıcı adına ve ({_email}) epostasına ait {result} adet kullanıcı bulundu, CheckUsernameEmail işlemi başarılı");
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff) içerisinde kullanıcı bulma işlemi başarısız oldu, hata : \n" + ex.Message, "CheckUsernameEmail(bool) Hatası");
            }
            return false;
        }

        ///<summary>
        ///[tblStaff] içerisinde kullanıcıAdına ve epostasına pin ve referans tanımla
        ///</summary>
        public void SetRefPin(string _username, string _email, string _pin, string _referance)
        {//tblStaff içerisinde kullanıcıAdına ve epostasına pin ve referans tanımla
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "Update tblStaff Set Pin = @P1 , Referans = @P2 where KullaniciAdi = @P3 AND Eposta = @P4";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _pin;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _referance;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = _username;
                    cmd.Parameters.Add("@P4", OleDbType.VarChar).Value = _email;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"(tblStaff) eposta : ({_email}) , kullanıcıadı : ({_username}), referansı : ({_referance}) içerisine pin atama işlemi başarılı oldu. Şifre yenileme.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)  eposta : ({_email})\nkullanıcıadı : ({_username})\nreferansı : ({_referance})\niçerisinde pin ve referans atama işlemi başarısız oldu, hata : \n" + ex.Message, "SetRefPin(void) Hatası");
            }
        }

        ///<summary>
        ///[tblStaff] içerisinde kullanıcıAdı Referans ve pin uyumuna bak, şifre yenileme durumunda kullanılır
        ///</summary>
        public bool CheckUsernameRefPin(string _username, string _referance, string _pin)
        {// kullanıcıAdı Referans ve pin uyumuna bak
            try
            {
                int result = -1;
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "select count(*) from tblStaff where KullaniciAdi = @P1 AND Referans = @P2 AND Pin = @P3";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _referance;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = _pin;

                    con.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

                if (result == 1)
                {
                    Console.WriteLine($"(tblStaff)\nkullanıcıadı : ({_username})\nreferansı : ({_referance})\niçerisinde pin okuma işlemi CheckRefPinUsername işlemi başarılı, kullanıcı bulundu");
                    return true;
                }
                else
                {
                    Console.WriteLine($"(tblStaff) içerisinde ({_username}) kullanıcı adına ve ({_referance}) epostasına ait ({result}) adet kullanıcı bulundu, CheckRefPinUsername işlemi başarılı");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)\nkullanıcıadı : ({_username})\nreferansı : ({_referance})\niçerisinde pin okuma işlemi başarısız oldu, hata : \n" + ex.Message, "CheckRefPinUsername(bool) Hatası");
            }
            return false;
        }

        ///<summary>
        ///[tblStaff] içerisinde kullanıcı adına ve parolasına uygun [1 adet] kayıt varsa true değeri döndürür
        ///</summary>
        public bool CheckLoginUser(TextBox _username, TextBox _password)
        {
            try
            {
                int result = -1;
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "select count(*) from tblStaff where KullaniciAdi = @P1 AND Parola = @P2";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username.Text;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _password.Text;
                    

                    con.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

                if (result == 1)
                {
                    Console.WriteLine($"(tblStaff)\nkullanıcıadı : ({_username.Text})\niçerisinde kullanıcı okuma işlemi CheckLoginUser işlemi başarılı, kullanıcı bulundu");
                    return true;
                }
                else
                {
                    Console.WriteLine($"(tblStaff)\nkullanıcıadı : ({_username.Text})\niçerisinde ({result}) adet kullanıcı bulundu, CheckLoginUser işlemi başarılı");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)\nkullanıcıadı : ({_username.Text})\niçerisinde kullanıcı okuma işlemi başarısız oldu, hata : \n" + ex.Message, "CheckLoginUser(bool) Hatası");
            }
            return false;
        }

        ///<summary>
        ///[tblStaff] içerisinde kullanıcı adına tanımlı epostayı döndürür
        ///</summary>
        public string GetEmailWithUsername(TextBox _username)
        {
            string result = "";
            try
            {

                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "select Eposta from tblStaff where KullaniciAdi = @P1";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = _username.Text;
                    


                    con.Open();
                    result = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                Console.WriteLine("GetEmailWithUsername metodu başarılı bir şekilde çalıştı");
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)\nkullanıcıadı : ({_username.Text})\niçerisinde GetEmailWithUsername metodu ile kullanıcı okuma işlemi başarısız oldu, hata : \n" + ex.Message, "GetEmailWithUsername(string) Hatası");
            }
            return result;
        }

        ///<summary>
        ///[tblStaff] içerisinde kullanıcı adına tanımlı Parolayı yeniler
        ///</summary>
        public void SetPassword(string _username, string newPassword)
        {//tblStaff içerisinde kullanıcıAdına ve epostasına pin ve referans tanımla
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "Update tblStaff Set Parola = @P1 where KullaniciAdi = @P2";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = newPassword;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = _username;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"(tblStaff) kullanıcıadı : ({_username}) kullanıcısının içerisine yeni parola atama işlemi başarılı oldu. Şifre yenileme.");
                MessageBox.Show("Parola yenileme başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)\nkullanıcıadı : ({_username})\nkullanıcısının içerisine yeni parola atama işlemi başarısız oldu, hata : \n" + ex.Message, "SetPassword(void) Hatası");
            }
        }

        ///<summary>
        ///[tblHistory] içerisinde yeni kayıt ekler
        ///</summary>
        public void newAcitonLog(string islemGerceklestiren ,string AlisSatisTipi, string islemTarih)
        {// tblHistory içerisinde işlemlerin kaydedilmesi
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //"INSERT INTO tblHistory (ogrAd, ogrNo, ogrEposta) VALUES (P1, P2, P3)"
                    cmd.CommandText = "Insert Into tblHistory (İslemGerceklestiren, IslemTipi, Tarih) Values (@P1, @P2, @P3)";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = islemGerceklestiren;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = AlisSatisTipi;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = islemTarih;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"(tblHistory) içerisinde yeni aksiyon kayıdı yazma işlemi başarılı oldu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("(tblHistory) içerisinde yeni aksiyon kayıdı yazma işlemi başarısız oldu, hata :\n" + ex.Message, "newAcitonLog(void) Hatası");
            }
        }

        ///<summary>
        ///[tblStaff] içerisinde ID'ye tanımlı kullanıcıadını ve epsotayi yeniler
        ///</summary>
        public void UpdateUsernameEmail(string newUserName, string newEmail, string ID)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "Update tblStaff Set KullaniciAdi = @P1, Eposta = @P2 where ID = @P3";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = newUserName;
                    cmd.Parameters.Add("@P2", OleDbType.VarChar).Value = newEmail;
                    cmd.Parameters.Add("@P3", OleDbType.VarChar).Value = ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"(tblStaff) ID : ({ID})'olan kullanıcının yeni kullanıcı adı ve epostası atama işlemi başarılı oldu. Kullanıcıadı ve eposta yenileme.");
                MessageBox.Show("Kullanıcıadı ve eposta yenileme başarılı", "İşlem Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)\n ID : ({ID})'olan kullanıcının yeni kullanıcı adı ve epostası atama işlemi başarısız oldu, hata : \n" + ex.Message, "UpdateUsernameEmail(void) Hatası");
            }
        }


        ///<summary>
        ///[tblStaff] içerisinde ID'ye tanımlı kullanıcıyı sil
        ///</summary>
        public void DeleteUser(string ID)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conStr))
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    //select COUNT(*) from tblStaff where KullaniciAdi = 'deneme' AND  Eposta = ' '
                    cmd.CommandText = "Delete from tblStaff where ID = @P3";
                    cmd.Parameters.Add("@P1", OleDbType.VarChar).Value = ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Console.WriteLine($"(tblStaff) ID : ({ID})'olan kullanıcı silme işlemi başarılı oldu. kullanıcı silme.");
                MessageBox.Show("Operatör silme başarılı", "İşlem Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"(tblStaff)\n ID : ({ID})'olan kullanıcıyi silme işlemi başarısız oldu, hata : \n" + ex.Message, "DeleteUser(void) Hatası");
            }
        }

    }
}
