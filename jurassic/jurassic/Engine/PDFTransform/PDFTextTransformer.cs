using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Spire.Pdf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jurassic.Engine.PDFTransform
{
    public class PDFTextTransformer
    {
        volatile int tCount = 0;
        public void Transform(string filename, string transformedfilename)
        {

        }

        public IEnumerable<string> TransformToText(string translatedFilepath)
        {
            List<string> texts = new List<string>();

            PdfReader reader = new PdfReader(translatedFilepath);

            for (int i = 1; i < reader.NumberOfPages; i++)
            {
                texts.Add(readPage(reader, i));
                Console.WriteLine("npages:" + i);
            }
            reader.Close();

            return texts;
        }

        private string readPage(PdfReader reader, int page)
        {
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            return PdfTextExtractor.GetTextFromPage(reader, page, strategy);
        }
    }
}
