using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;

class LoadCdrExample
{
    static void Main()
    {
        // Path to the CDR file
        string cdrFilePath = "sample.cdr";

        // Open a file stream for reading the CDR file
        using (FileStream stream = new FileStream(cdrFilePath, FileMode.Open, FileAccess.Read))
        {
            // Create load options specific for CDR format
            CdrLoadOptions loadOptions = new CdrLoadOptions();

            // Initialize CdrImage with the stream and load options
            using (CdrImage cdrImage = new CdrImage(stream, loadOptions))
            {
                // Retrieve and display the detected file format
                var format = cdrImage.FileFormat;
                Console.WriteLine($"Loaded file format: {format}");

                // Additional processing can be performed here using cdrImage
            }
        }
    }
}