using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace case400_csv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var filePath = @"C:\Users\y-morioka\Documents\FI_JRK_0004.csv";
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.GetEncoding("Shift_JIS"),
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using (var reader = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS")))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<CsvRecord>().ToList();

                    // デバッグ出力用
                    foreach (var record in records)
                    {
                        Console.WriteLine($"Record Number: {record.RecordNumber}, Individual Number: {record.IndividualNumber}");
                    }

                    dataGridView1.DataSource = records;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました:" + ex.Message);
            }
        }

        public class CsvRecord
        {
            [Name("要求レコード番号")]
            public String RecordNumber { get; set; }

            [Name("個人番号")]
            public String IndividualNumber { get; set; }

            [Name("照会結果氏名")]
            public String InquiryResultName { get; set; }

            [Name("照会結果氏名かな")]
            public String InquiryResultNameKana { get; set; }

            [Name("照会結果生年月日")]
            public String InquiryResultBirth { get; set; }

            [Name("照会結果性別コード")]
            public String InquiryResultGenderCode { get; set; }

            [Name("照会結果性別")]
            public String InquiryResultGender { get; set; }

            [Name("照会結果住所")]
            public String InquiryResultAddress { get; set; }

            [Name("市町村コード")]
            public String MunicipalityCode { get; set; }

            [Name("対象者識別情報")]
            public String IdentificationInformation { get; set; }

            [Name("照会処理結果コード")]
            public String InquiryProcessingResultCode { get; set; }

            [Name("照会処理結果")]
            public String InquiryProcessingResult { get; set; }

            [Name("照会結果レコード数")]
            public String InquiryResultRecordCount { get; set; }

            [Name("照会結果レコード連番")]
            public String InquiryResultRecordSerial { get; set; }

            [Name("異動有無コード")]
            public String TransferStatusCode { get; set; }

            [Name("異動有無")]
            public String TransferStatus { get; set; }

            [Name("生存状況コード")]
            public String SuevivalStatusCode { get; set; }

            [Name("生存状況")]
            public String SuevivalStatus { get; set; }

            [Name("変更状況コード")]
            public String ChangeStatusCode { get; set; }

            [Name("変更状況")]
            public String ChangeStatus { get; set; }

            [Name("異動事由コード")]
            public String ReasonTransferCode { get; set; }

            [Name("異動事由")]
            public String ReasonTransfer { get; set; }

            [Name("異動年月日")]
            public String DateOfTransfer { get; set; }

            [Name("照会結果氏名外字数")]
            public String InquiryResaltOutsideName { get; set; }

            [Name("照会結果住所外字数")]
            public String InquiryResaltOutsideAddress { get; set; }

            [Name("不参加団体対象フラグ")]
            public String FlagNonParticipant { get; set; }

            [Name("不参加団体対象要因")]
            public String ReasonNonParticipant { get; set; }
        }

    }
}
