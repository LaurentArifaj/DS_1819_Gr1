using System;

public class DES
{
    public static String Enkripto(String plainTxt)
    {
        DESCryptoServiceProvider objDes =
            new DESCryptoServiceProvider();
        //Key dhe IV generohen nga crypto serveri dhe klienti
        objDes.Key = Encoding.UTF8.GetBytes(txtCelesi.Text);
        objDes.IV = Encoding.UTF8.GetBytes("12345678");
        objDes.Padding = PaddingMode.Zeros;
        objDes.Mode = CipherMode.CBC;

        byte[] bytePlaintexti =
            Encoding.UTF8.GetBytes(plainTxt);

        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms,
                            objDes.CreateEncryptor(),
                            CryptoStreamMode.Write);
        cs.Write(bytePlaintexti, 0, bytePlaintexti.Length);
        cs.Close();

        byte[] byteCiphertexti = ms.ToArray();

        return Convert.ToBase64String(byteCiphertexti);

        //Encoding.UTF8.GetString(byteCiphertexti);
    }

    public static String Dekripto(String encTxt)
    {

        DESCryptoServiceProvider objDes =
            new DESCryptoServiceProvider();
        //Key dhe IV gjenerohen nga serveri ose klienti
        objDes.Key = Encoding.UTF8.GetBytes(txtCelesi.Text);
        objDes.IV = Encoding.UTF8.GetBytes("12345678");
        objDes.Padding = PaddingMode.Zeros;
        objDes.Mode = CipherMode.CBC;

        byte[] byteCiphertexti =
            Convert.FromBase64String(encTxt);
        MemoryStream ms = new MemoryStream(byteCiphertexti);
        CryptoStream cs =
            new CryptoStream(ms,
            objDes.CreateDecryptor(),
            CryptoStreamMode.Read);

        byte[] byteTextiDekriptuar = new byte[ms.Length];
        cs.Read(byteTextiDekriptuar, 0, byteTextiDekriptuar.Length);
        cs.Close();

        txtTextiDekriptuar.Text =
            Encoding.UTF8.GetString(byteTextiDekriptuar);
    }
}
}
