using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR file path
        string inputPath = "input.cdr";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Read the CDR file into a byte array
        byte[] cdrData = File.ReadAllBytes(inputPath);

        // Load the CDR image from the byte array using a MemoryStream
        using (MemoryStream inputStream = new MemoryStream(cdrData))
        {
            // Create default CDR load options
            var loadOptions = new CdrLoadOptions();

            // Initialize CdrImage with the stream and load options
            using (CdrImage cdrImage = new CdrImage(inputStream, loadOptions))
            {
                // Prepare a memory stream to receive the PNG output
                using (MemoryStream pngStream = new MemoryStream())
                {
                    // Set PNG save options (default settings)
                    var pngOptions = new PngOptions();

                    // Save the CDR image as PNG into the memory stream
                    cdrImage.Save(pngStream, pngOptions);

                    // Optional: write the PNG data to a file for verification
                    string outputPath = Path.Combine("output", "result.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Write the PNG bytes to the file
                    File.WriteAllBytes(outputPath, pngStream.ToArray());
                }
            }
        }
    }
}