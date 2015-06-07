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

        //public IEnumerable<string> ExtremeTransformToText(string translatedFilepath)
        //{
        //    SortedList<int, string> sections = new SortedList<int, string>();


        //    PdfDocument doc = new PdfDocument();
        //    doc.LoadFromFile(translatedFilepath);
        //    int count = 0;

        //    ConcurrentDictionary<int, PdfDocument> pages = new ConcurrentDictionary<int, PdfDocument>();
        //    foreach (PdfPageWidget item in doc.Pages)
        //    {
        //        PdfDocument doca = new PdfDocument();
        //        doca.LoadFromFile(translatedFilepath);
        //        pages.TryAdd(count, doca);
        //        count++;
        //    }

        //    Parallel.ForEach(pages, x =>
        //    {
        //        Console.WriteLine("Start:" + x.Key);
        //        Console.WriteLine("tCount:" + tCount++);
        //        sections.Add(x.Key, x.Value.Pages[x.Key].ExtractText());
        //        Console.WriteLine("tCount:" + tCount--);
        //        Console.WriteLine("End:" + x.Key);
        //    });
            
        //    doc.Close();
        //    return sections.Values;
        //}

        public IEnumerable<string> TransformToText(string translatedFilepath)
        {
            List<string> sections = new List<string>();


            Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
            doc.LoadFromFile(translatedFilepath);
            int count = 0;

            foreach (PdfPageBase item in doc.Pages)
            {
                sections.Add(item.ExtractText());
                Console.WriteLine(count++);
            }
            
            doc.Close();
            return sections;
        }

        public IEnumerable<string> TransformToText_PDF2Text(string translatedFilepath)
        {
            List<string> texts = new List<string>();

            PdfReader reader = new PdfReader(translatedFilepath);
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

            for (int i = 1; i < reader.NumberOfPages; i++)
            {
                texts.Add(PdfTextExtractor.GetTextFromPage(reader, i, strategy));
            }
            reader.Close();

            return texts;
        }
    }
}
