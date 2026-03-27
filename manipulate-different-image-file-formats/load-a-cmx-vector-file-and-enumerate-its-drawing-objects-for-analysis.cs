using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            var doc = cmx.Document;
            var pages = ((Aspose.Imaging.FileFormats.Cmx.ObjectModel.CmxDocument)doc).Pages;

            Console.WriteLine($"CMX document contains {pages.Count} page(s).");

            int pageIndex = 0;
            foreach (var page in pages)
            {
                Console.WriteLine($"Page {pageIndex}");
                pageIndex++;
            }
        }
    }
}