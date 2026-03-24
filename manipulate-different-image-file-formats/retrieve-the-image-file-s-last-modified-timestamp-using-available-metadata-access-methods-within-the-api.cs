using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "input.png";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Retrieve the last modified timestamp
            DateTime modifyDate = ((RasterImage)image).GetModifyDate(true);

            // Output the timestamp
            Console.WriteLine($"Last modified: {modifyDate}");
        }
    }
}