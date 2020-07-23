using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;

namespace HiddenTextInPdfReportSampleProject
{
    public partial class Form1 : Form
    {
        string[] words = { "compliant ", "product ", "Documentation ", "the ", "establishing ", "customer ", "facilitate ", "ISO 14971:2019 ", "EN ISO 14971:2019 ", "that will facilitate " };

        public Form1()
        {
            InitializeComponent();
        }

        public string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        public string getRandomWords()
        {
            string res = "";
            Random r = new Random();
            int rloop = r.Next(0, 30);
            for (int i = 0; i< rloop; i++ )
            {
                int rInt = r.Next(0, 9); //for ints                
                string word = words[rInt];
                res = res + word;
            }
            
            return res;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            

            DetailBand detailBand = new DetailBand();
            PageFooterBand pageFooter = new PageFooterBand();
            PageHeaderBand pageHeader = new PageHeaderBand();
            XtraReport xtraReport = new XtraReport();

            XRRichText red_header = new XRRichText();
            red_header.SizeF = new SizeF(1000, 0F);
            red_header.Rtf = "{\\rtf1\\deff0 \\stshfdbch3\\stshfloch2\\stshfhich2\\stshfbi1{\\fonttbl{\\f0 Calibri;}{\\fbiminor\\f1 Times New Roman;}{\\fhiminor\\f2 Calibri;}{\\fdbminor\\f3 Times New Roman;}{\\f4 Arial;}{\\f5 Times New Roman;}}{\\colortbl ;\\red0\\green0\\blue255 ;}{\\*\\defchp \\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\cgrid1\\fs22}{\\stylesheet {\\ql\\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\fs22 Normal;}{\\s1\\sbasedon0\\snext1\\ql\\sl275\\slmult1\\sa100\\tqc\\tx4513\\tqr\\tx9026\\fcs1\\f4\\fcs1\\f4\\dbch\\af5\\hich\\af4\\loch\\af4\\fs20 header;}{\\*\\cs2\\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\fs22 Default Paragraph Font;}{\\*\\cs3\\sbasedon2\\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\fs22 Line Number;}{\\*\\cs4\\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\fs22\\ul\\cf1 Hyperlink;}{\\*\\ts5\\tsrowd\\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\fs22\\ql\\tscellpaddfl3\\tscellpaddl108\\tscellpaddfb3\\tscellpaddfr3\\tscellpaddr108\\tscellpaddft3\\tsvertalt\\cltxlrtb Normal Table;}{\\*\\ts6\\tsrowd\\sbasedon5\\fcs1\\f1\\fcs1\\f1\\hich\\af2\\loch\\af2\\dbch\\af3\\fs22\\ql\\trbrdrt\\brdrs\\brdrw10\\trbrdrl\\brdrs\\brdrw10\\trbrdrb\\brdrs\\brdrw10\\trbrdrr\\brdrs\\brdrw10\\trbrdrh\\brdrs\\brdrw10\\trbrdrv\\brdrs\\brdrw10\\tscellpaddfl3\\tscellpaddl108\\tscellpaddfr3\\tscellpaddr108\\tsvertalt\\cltxlrtb Table Simple 1;}}{\\*\\listoverridetable}{\\info{\\creatim\\yr2020\\mo7\\dy6\\hr16\\min58}{\\version1}}\\nouicompat\\splytwnine\\htmautsp\\alntblind\\expshrtn\\spltpgpar\\nogrowautofit\\utinl\\sectd\\trowd\\irow0\\irowband-1\\lastrow\\trgaph108\\trbrdrb\\brdrs\\brdrw10\\trleft-87\\trrh1275\\trftsWidth3\\trwWidth8925\\trpaddfl3\\trpaddl108\\trpaddfb3\\trpaddfr3\\trpaddr108\\trpaddft3\\tbllkhdrcols\\tbllkhdrrows\\tbllknocolband\\tblindtype3\\tblind21\\clvertalc\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth2505\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx2418\\clvertalt\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth2310\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx4728\\clvertalt\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth2175\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx6903\\clvertalt\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth1935\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx8838\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs14\\par\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs14\\cell\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af1\\alang3081\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang3081\\langfe3081\\langnp3081\\langfenp3081\\b\\cf0 xxx}{\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\cf0 Office}\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af5\\alang1025\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\cf0 Xxxxxx Xxxxx,  \\line Xxxxxxxx, Xxxxxxxxx\\line Xxxxxxxx, Xxxxxxxxx\\line Xxxxxxxx, Xxxxxxxxx\\line xxx x\\line xxx x\\line xxx x}{\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang3081\\langfe3081\\langnp3081\\langfenp3081\\cf0 \\line }\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\cell\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af1\\alang3081\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang3081\\langfe3081\\langnp3081\\langfenp3081\\b\\cf0 xxx}{\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\cf0 Office}\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af5\\alang1025\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\cf0 Xxxxxx Xxxxx,  \\line Xxxxxxxx, Xxxxxxxxx\\line Xxxxxxxx, Xxxxxxxxx\\line Xxxxxxxx, Xxxxxxxxx\\line xxx x\\line xxx x\\line xxx x}\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\cell\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af1\\alang3081\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang3081\\langfe3081\\langnp3081\\langfenp3081\\b\\cf0 xxx}{\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\cf0 Office}\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af1\\ltrch\\fcs0\\loch\\af2\\dbch\\af3\\hich\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\cf0 \\~}\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\par\\pard\\plain\\ql\\intbl{\\fcs1\\af5\\alang1025\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\cf0 Xxxxxx Xxxxx,  \\line Xxxxxxxx, Xxxxxxxxx\\line Xxxxxxxx, Xxxxxxxxx\\line Xxxxxxxx, Xxxxxxxxx\\line xxx x\\line xxx x\\line xxx x}\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\par\\pard\\plain\\ql\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\par\\pard\\plain\\qr\\intbl\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs16\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\b\\cell\\trowd\\irow0\\irowband-1\\lastrow\\trgaph108\\trbrdrb\\brdrs\\brdrw10\\trleft-87\\trrh1275\\trftsWidth3\\trwWidth8925\\trpaddfl3\\trpaddl108\\trpaddfb3\\trpaddfr3\\trpaddr108\\trpaddft3\\tbllkhdrcols\\tbllkhdrrows\\tbllknocolband\\tblindtype3\\tblind21\\clvertalc\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth2505\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx2418\\clvertalt\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth2310\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx4728\\clvertalt\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth2175\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx6903\\clvertalt\\clbrdrt\\brdrnone\\clbrdrl\\brdrnone\\clbrdrb\\brdrs\\brdrw10\\clbrdrr\\brdrnone\\cltxlrtb\\clftsWidth3\\clwWidth1935\\clpadfb3\\clpadfl3\\clpadfr3\\clpadr108\\clpadft3\\clpadt108\\cellx8838\\row\\pard\\plain\\ql\\fcs1\\af1\\ltrch\\fcs0\\hich\\af2\\dbch\\af3\\loch\\f2\\fs22\\lang1033\\langfe1033\\langnp1033\\langfenp1033\\par{\\*\\themedata \r\n504b03041400020008000000210201159325ae000000270100000b0000005f72656c732f2e72656c738d8f310ec2300c45af1279a76e1910424dbbb07460415c204a9d34a24da224457036068ec415c8d82206164b5ffe7efffbfd7cd5ed7d1ad98d4234\r\nce72a88a121859e97a63358739a9cd1edaa63ed3285276c4c1f8c8f2898d1c8694fc0131ca8126110be7c9e68d72611229cba0d10b79159a705b963b0c4b06ac99aceb3984aeaf805d1e9efe613ba58ca4a393f34436fd88f87264b2089a12879499848b\r\n791236b70c454e00864d8dab779b0f504b0304140002000800000021027f624aeb730000007b0000001c0000007468656d652f7468656d652f7468656d654d616e616765722e786d6c0d8cc10d83300c005789fc2f4e7954554460820e61810991888392\r\nb465b73e3a5257a89fa7d3ddeff31da633ede6c5a5c62c1eae9d05c332e7254af0f06cebe50ed338906b1b277e9050e062b491eac8c3d6dae110ebac966a970f16756b2e899a6209b8147aeb2bedd85b7bc34451c0e0f807504b03041400020008000000\r\n21020a5d705ea60000000c010000270000007468656d652f7468656d652f5f72656c732f7468656d654d616e616765722e786d6c2e72656c738dcf3d0ec2300c05e0ab44dea95b068450d32e2c5d11178852278d687e94a408cec6c091b8021113951818\r\n9fecf7597e3d9e6d7fb333bb524cc63b0e4d55032327fd689ce6b064b5d943dfb5279a452e1b693221b1527189c39473382026399115a9f2815c99281fadc825468d41c88bd084dbbade61fc36606db261e41087b10176be07fac7f64a1949472f174b2e\r\nff3881b974a980226aca1c3eb1a90a030cbb16573f756f504b0304140002000800000021026d52debf9f050000fd1b0000160000007468656d652f7468656d652f7468656d65312e786d6ced594f6fdb3614ff2a84eead2c5b729da06e113b76bb356983\r\nc4ebd0232dd3126b4a14483aa96f437b1c30605837ec3260b71d866d015a608765d887c9d661eb807c8551b42c5136d5244d566c587cb045eaf7deeffde17b22e5939f7eb979fb4944c03e621cd3b86d39d76b1640b14f47380edad6548cafb5acdbb76e\r\nc27511a20801098ef93a6c5ba110c9ba6d735f4e437e9d262896f7c6944550c8210bec118307524944ec7aadd6b42388630bc430426debc1788c7d0406a94a2b57de23f22b163c9df009dbf315a32ea1b0a38993fef019ef1206f621695b9267440f06e8\r\n89b000815cc81b6daba63e16b06fddb47329222a8435c1befa2c043389d1a4ae045930cc259dbebb7663b360a8cf195681bd5eafdb730a8d0a017d5f7aebac80dd7ecbe9e45a35d4fc72557bb7e6d5dc25018da1b122b0d6e974bcb5b240a3107057045a\r\nb5a6bb512f0bb88580b7ea4367a3db6d9605bc42a0b922d0bfb1d6749704142a24389eacc0d3cc1629ca31634aee1af12d896fe56ba180d9da4a9b2b8845d5ba8be063cafa12a0b20c058e819825680c7d89ebc268c830540c701d41ed5636e7f3d5b994\r\n0e709fe144b4adf713280ba4c09c1c7d7772f4029c1c1d1e3f7d79fcf4c7e367cf8e9ffe6092bc0be340977cfdcda77f7df511f8f3c5d7af9f7f5e21c07581dfbefff8d79f3fab400a1df9ea8bc3df5f1ebefaf2933fbe7d6ec26f3038d4f1031c210eee\r\na303b04ba3d43f03051ab2738a0c42884b2230945013b227c212f2fe0c1223b083ca317cc8645b3022ef4c1f97ecdd0bd9546013f25e189590db94920e65669fee293acda7691c54f0b3a90edc8570df48df5dca726f9ac8958d8d4abb212a99ba4364e2\r\n61806224407a8f4e1032c93dc2b814df6dec33cae95880471874203607668087c22c751747324133a38d32eba5086d3f041d4a8c049b68bf0c95150289512922a568de81530123b3d530223a740b8ad068e8de8cf9a5c07321931e2042416f8438370a3d\r\n60b392c9f7a06c51e615b04d665119ca049e18a15b90521dba4927dd104689d96e1c873af83d3e912b16821d2acc76d072cda4639910185767fe2146e29cc5fe010e42f36249ef4c99b146102dd7e88c8c218a170f80522b8f70fca6be4eb06cec577d7d\r\na9af6fc8879db19e96bb7925f03fdac337e134de41699d5cb5f0ab167ed5c2df50e1ff44e32e7ab5adefd6959ea872eb3ec684ec8919415b5c75792e5d1cf5e5a41a28a1fca89084f272c15702060caa6bc0a8f8108b702f8489e4711445c033dd010709\r\ne5f28862552a57275e2cbd56735e7e4c957028b6e9683edf289d5f73456a14709daa91aa382b5de3c645e99c39f28c7c8e57c1e7bd99cfd6622acb08c0f47d84d3ac6766721f12344aa33f572d3041bbc81799be45ae2e3d6f3c84239425ce317be634ce\r\n1ac9d6e981d4f8d61a17e53b4be67442b78ad0bb8cd4d54e4b9dbd5ab9242e8fc08134d3ab7b16f0a344eae4693b832488db962f32874e2df665b72b56ac53ab76bb4492302e36210fe762ea56feee272eecae7b6eaaee02869bbad419c91b2de7dd93db\r\ncb0944e3b14c7cc54c31cceed1a9406c2f1c1d802199b25d282d77e74b6a84b97c78d41703268bd3cd565bb9e8b3c5bffc2e292b0a48921066eda9a5e77a8e57d7b9116aa4d9675718ff96be342ed117efffec4bba7ce526b83152a735b9356010a4ebb4\r\n6d5126422adb4d1262bfcfe466429149c3803c06aafe44d277e2a9b1687fd1afec859279770b42b18b03c0b06c71226408ed88ccd353b4398b76989547a629eb2db9c13c99ff0ed13e2283b4729b69082c10e60d248b85022e27ce36d5d830e8ff9b3744\r\n6ed586e8941d4341e59e6783e2eaed5e7b0aac5dd48a733e6deb156ed7bdb33f6d13799e01e9976ce498f9a4d8fe0ea87ac416fb4db924afb5b252cc2787d2ea96ee5faaeb5d6eaf8ab4b4aa56c1a5ee53b5f837aae27f0ae1dbc7df3384df3b57f4edd5\r\n62b6b593901a2dfdb7b698b9f537504b030414000200080000002102e9278183ee00000010020000130000005b436f6e74656e745f54797065735d2e786d6cad914d4ec3301085af62795bc54e5920849274012cf959708191334e2ce21fd993aa9c8d05\r\n47e20a4cd382102a48486c2cd9efcdfb66c66f2fafcd66e727b1c55c5c0cad5cab5a0a0c26f62e0cad9cc9561772d3358fcf098b606b28ad1c89d2a5d6c58ce8a1a89830b06263f6407ccd834e609e60407d56d7e7dac44018a8a27d86ec9a6bb4304f24\r\n6e76fc7cc0669c8a145707e39ed54a486972068875bd0dfd374a752428ae5c3c6574a9acd820853e8958a41f091f85f7bc89ec7a140f90e90e3cdb34f198f8f55cabdfc34eb41bad7506fb6866cf256a8959fd097a0b81e7cdff833e867d76a097ffedde\r\n01504b010214001400020008000000210201159325ae000000270100000b00000000000000000000000000000000005f72656c732f2e72656c73504b01021400140002000800000021027f624aeb730000007b0000001c00000000000000000000000000\r\nd70000007468656d652f7468656d652f7468656d654d616e616765722e786d6c504b01021400140002000800000021020a5d705ea60000000c0100002700000000000000000000000000840100007468656d652f7468656d652f5f72656c732f7468656d\r\n654d616e616765722e786d6c2e72656c73504b01021400140002000800000021026d52debf9f050000fd1b000016000000000000000000000000006f0200007468656d652f7468656d652f7468656d65312e786d6c504b01021400140002000800000021\r\n02e9278183ee000000100200001300000000000000000000000000420800005b436f6e74656e745f54797065735d2e786d6c504b050600000000050005005d010000610900000000}{\\*\\colorschememapping 3c3f786d6c2076657273696f6e3d22312e\r\n302220656e636f64696e673d227574662d38223f3e3c613a636c724d617020786d6c6e733a613d22687474703a2f2f736368656d61732e6f70656e786d6c666f726d6174732e6f72672f64726177696e676d6c2f323030362f6d61696e22206267313d22\r\n6c743122207478313d22646b3122206267323d226c743222207478323d22646b322220616363656e74313d22616363656e74312220616363656e74323d22616363656e74322220616363656e74333d22616363656e74332220616363656e74343d226163\r\n63656e74342220616363656e74353d22616363656e74352220616363656e74363d22616363656e74362220686c696e6b3d22686c696e6b2220666f6c486c696e6b3d22666f6c486c696e6b22202f3e}}"; 
            pageHeader.Controls.Add(red_header);

            xtraReport.Landscape = true;
            xtraReport.ReportUnit = ReportUnit.TenthsOfAMillimeter;

            xtraReport.Bands.Add(detailBand);
            xtraReport.Bands.Add(pageFooter);
            xtraReport.Bands.Add(pageHeader);

            xtraReport.Margins.Left = 50;
            xtraReport.Margins.Right = 50;
            xtraReport.Margins.Top = 10;
            xtraReport.Margins.Bottom = 10;
            pageFooter.Height = 50;
            pageHeader.Height = 50;

            XRPageInfo xRPageInfo = new XRPageInfo()
            {
                StartPageNumber = 1,
                Format = "Page {0} of {1}"
            };
            xRPageInfo.Font = new Font("Arial", 8, FontStyle.Regular);
            pageFooter.Controls.Add(xRPageInfo);

            float aval_width = xtraReport.PageWidth - xtraReport.Margins.Left - xtraReport.Margins.Right;

            String line;
            System.IO.StreamReader file = new System.IO.StreamReader(@".\..\..\data_for_hidden_text.txt");

            XRTable table = new XRTable();
            table.Font = new Font("Arial", 12, FontStyle.Regular);
            table.KeepTogether = true;
            table.SizeF = new SizeF(1000,  0F);
            table.Borders = DevExpress.XtraPrinting.BorderSide.All;
            table.BeginInit();
            int line_number = 0;
            while ((line = file.ReadLine()) != null)
            {
                line_number++;
                XRTableRow row = new XRTableRow();

                XRTableCell cell = new XRTableCell();
                cell.Text = $"HRS-2XS-IRC-005 l{line_number}";
                cell.WidthF = 220;
                row.Cells.Add(cell);

                cell = new XRTableCell();
                cell.WidthF = 580;
                XRRichText richtext = new XRRichText();
                richtext.Html = ConvertHexToString(line, System.Text.Encoding.ASCII);
                richtext.Borders = (DevExpress.XtraPrinting.BorderSide)BorderSide.None;
                richtext.Location = new Point(0, 0);
                richtext.Size = cell.Size;
                cell.Controls.Add(richtext);               
                row.Cells.Add(cell);

                table.Rows.Add(row);
            }
                       
            table.LocationF = new PointF(0, 0);
            detailBand.Controls.Add(table);
            table.EndInit();
            String fileName = Directory.GetCurrentDirectory() + "reportWithHiddenText.pdf";
            xtraReport.ExportToPdf(fileName);
            System.Diagnostics.Process.Start(fileName, "");
        }

    }
}
