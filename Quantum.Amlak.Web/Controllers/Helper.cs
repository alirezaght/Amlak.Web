using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using PersianDate;
using Quantum.Amlak.Web.Models;

namespace Quantum.Amlak.Web.Controllers
{
    public static class Helper
    {
        public const string AmlakFilesFolderPath = "d:/AmlakFiles";
        public const int ResponseFileDayLength = 350;


        private static void CreateResponseJsonFile(string fileName)
        {
            using (var dbc = new AmlakMainEntities())
            using (var outPut = new StreamWriter(File.OpenWrite(fileName)))
            using (var jsonWriter = new JsonTextWriter(outPut))
            {
                jsonWriter.Formatting = Formatting.Indented;

                var fromDate = ConvertToPersianDateTime(DateTime.Now.AddDays(-ResponseFileDayLength));
                var toDate = ConvertToPersianDateTime(DateTime.Now);

                jsonWriter.WriteStartObject();

                WriteRentApartments(dbc, jsonWriter, fromDate, toDate);
                WriteSaleApartments(dbc, jsonWriter, fromDate, toDate);
                WriteRentMostaghelat(dbc, jsonWriter, fromDate, toDate);
                WriteSaleMostaghelat(dbc, jsonWriter, fromDate, toDate);
                WriteRentMaghaze(dbc, jsonWriter, fromDate, toDate);
                WriteSaleMaghaze(dbc, jsonWriter, fromDate, toDate);
                WriteRentVila(dbc, jsonWriter, fromDate, toDate);
                WriteSaleVila(dbc, jsonWriter, fromDate, toDate);
                WriteSaleZamin(dbc, jsonWriter, fromDate, toDate);



                jsonWriter.WriteEndObject();

            }
        }

        private static void WriteSaleZamin(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Zamin-Sale");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetSaleZamin(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteSaleVila(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Vila-Sale");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetSaleVila(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteRentVila(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Vila-Rent");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetRentVila(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteSaleMaghaze(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Maghaze-Sale");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetSaleMaghaze(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteRentMaghaze(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Maghaze-Rent");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetRentMaghaze(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteRentMostaghelat(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Mostaghelat-Rent");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetRentMostaghelat(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteSaleMostaghelat(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Mostaghelat-Sale");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetSaleMostaghelat(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();

        }

        private static void WriteSaleApartments(AmlakMainEntities dbc, JsonTextWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Apartments-Sale");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetSaleApartments(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        private static void WriteRentApartments(AmlakMainEntities dbc, JsonWriter writer, string fromDate, string toDate)
        {
            writer.WritePropertyName("Apartments-Rent");
            writer.WriteStartArray();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var partOfFiles = dbc.GetRentApartments(fromDate, toDate,
                    i * AmlakMainEntities.MaxResponseLength).ToList();
                if (partOfFiles.Count == 0)
                    break;

                foreach (var arFile in partOfFiles)
                {
                    var serializedFile = JsonConvert.SerializeObject(arFile);
                    writer.WriteRawValue(serializedFile);
                }
            }


            writer.WriteEndArray();
        }

        public static string[] CreateAmlakResponse(string deviceId)
        {
            var mainFilePath = Path.Combine(AmlakFilesFolderPath, deviceId + ".amf");

            if (!Directory.Exists(AmlakFilesFolderPath))
                Directory.CreateDirectory(AmlakFilesFolderPath);
            var filePaths = new[]
            {
                Path.Combine(AmlakFilesFolderPath, deviceId + "_json.txt"),
                Path.Combine(AmlakFilesFolderPath, deviceId + "_zipped.txt"),
                Path.Combine(AmlakFilesFolderPath, deviceId + "_zipped_encrypt.txt"),
                Path.Combine(AmlakFilesFolderPath, deviceId + "_zipped_decrypt.txt"),
                Path.Combine(AmlakFilesFolderPath, deviceId + "_unzipped_decrypt.txt")
            };
            CreateResponseJsonFile(filePaths[0]);

            CompressFile(filePaths[0], filePaths[1]);

            var keys = EncryptFile(filePaths[1], filePaths[2]);


            if (File.Exists(mainFilePath))
                File.Delete(mainFilePath);
            File.Copy(filePaths[1], mainFilePath);

#if DEBUG

            DecryptedFile(filePaths[2], filePaths[3], keys);
            DecompressFile(filePaths[3], filePaths[4]);

#else
            foreach (var filePath in filePaths)
                if (File.Exists(filePath))
                    File.Delete(filePath);
#endif


            var retValue = new[]
            {
                deviceId + ".amf",
                Encoding.ASCII.GetString(keys[0]),
                Encoding.ASCII.GetString(keys[1])
            };

            return retValue;
        }

        public static byte[][] EncryptFile(string inputFile, string outputFile)
        {
            using (var aesManager = new AesManaged())
            using (var inputStream = File.OpenRead(inputFile))
            //            using (var streamReader = new StreamReader(inputStream))
            using (var fileStreamWriter = File.OpenWrite(outputFile))
            {
                aesManager.GenerateKey();
                var encryptor = aesManager.CreateEncryptor(aesManager.Key, aesManager.IV);
                using (var csEncrypt = new CryptoStream(fileStreamWriter, encryptor, CryptoStreamMode.Write))
                //                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    inputStream.CopyTo(csEncrypt);
                    //                    var tmp = streamReader.ReadToEnd();
                    //                    swEncrypt.Write(tmp);

                    return new[] { aesManager.Key, aesManager.IV };
                }
            }
        }

        public static void DecryptedFile(string inputFile, string outputFile, byte[][] key)
        {
            if (key == null)
                throw new ArgumentException("Key value can not be null", "key");

            using (var aesManager = new AesManaged())
            using (var inputStream = File.OpenRead(inputFile))
            using (var outputStream = File.OpenWrite(outputFile))
            //            using (var fileStreamWriter = new StreamWriter(outputStream))
            {
                aesManager.Key = key[0];
                aesManager.IV = key[1];
                var decryptor = aesManager.CreateDecryptor(aesManager.Key, aesManager.IV);
                using (var csEncrypt = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                //                using (var swEncrypt = new StreamReader(csEncrypt))
                {
                    csEncrypt.CopyTo(outputStream);
                    //                    var tmp = swEncrypt.ReadToEnd();
                    //                    fileStreamWriter.Write(tmp);
                }
            }
        }

        public static string ConvertToPersianDateTime(DateTime date)
        {
            return ConvertDate.ToFa(date);
        }

        public static void CompressFile(string inputFile, string outputFile)
        {
            using (var inputFileStream = File.OpenRead(inputFile))
            {
                using (var outputFileStream = File.OpenWrite(outputFile))
                {
                    using (var compressionStream = new GZipStream(outputFileStream,
                       CompressionMode.Compress))
                    {
                        inputFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }

        public static void DecompressFile(string inputFile, string outputFile)
        {
            using (var inputFileStream = File.OpenRead(inputFile))
            {
                using (var outputFileStream = File.OpenWrite(outputFile))
                {
                    using (var compressionStream = new GZipStream(inputFileStream,
                       CompressionMode.Decompress))
                    {
                        compressionStream.CopyTo(outputFileStream);
                    }
                }
            }
        }
    }
}