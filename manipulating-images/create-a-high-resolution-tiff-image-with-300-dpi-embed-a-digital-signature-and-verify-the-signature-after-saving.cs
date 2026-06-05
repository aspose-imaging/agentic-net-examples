using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output\\highres.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create a blank 500x500 TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, 500, 500))
            {
                // Set resolution to 300 DPI
                tiffImage.SetResolution(300, 300);

                // Embed a digital signature with a valid password
                string password = "secure123";
                tiffImage.EmbedDigitalSignature(password);

                // Save the image to the specified path
                tiffImage.Save(outputPath, tiffOptions);
            }

            // Verify that the file was created
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Load the saved image and verify the digital signature
            using (TiffImage loadedImage = (TiffImage)Image.Load(outputPath))
            {
                bool isSigned = loadedImage.IsDigitalSigned("secure123", 0);
                Console.WriteLine($"Signature verification result: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}