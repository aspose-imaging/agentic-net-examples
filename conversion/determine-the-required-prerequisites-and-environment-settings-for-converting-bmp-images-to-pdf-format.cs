using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // ==============================
        // Prerequisites & environment setup
        // ==============================
        // 1. Add the Aspose.Imaging for .NET NuGet package to the project:
        //    Install-Package Aspose.Imaging
        // 2. Obtain a valid Aspose.Imaging license file (e.g., "Aspose.Imaging.lic") and set it at runtime
        //    to remove evaluation limitations.
        // 3. Target a compatible .NET runtime (e.g., .NET Framework 4.6+, .NET Core 2.0+, .NET 5/6/7).
        // 4. Ensure the application has read access to the source BMP file and write access to the
        //    destination folder where the PDF will be created.
        // 5. No additional native dependencies are required; Aspose.Imaging is a pure .NET library.

        // ==============================
        // Example: Convert BMP to PDF
        // ==============================
        string bmpPath = @"C:\temp\sample.bmp";
        string pdfPath = @"C:\temp\sample.pdf";

        // Load the BMP image using the Aspose.Imaging lifecycle rule (Image.Load)
        using (Image bmpImage = Image.Load(bmpPath))
        {
            // Create PDF save options (default settings are sufficient for most cases)
            var pdfOptions = new PdfOptions();

            // Optional: customize PDF options, e.g., set compression level or image resolution
            // pdfOptions.Compression = PdfCompressionLevel.BestCompression;
            // pdfOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            // Save the image as PDF using the Aspose.Imaging lifecycle rule (Image.Save)
            bmpImage.Save(pdfPath, pdfOptions);
        }

        // ==============================
        // End of conversion
        // ==============================
        Console.WriteLine("BMP image successfully converted to PDF.");
    }
}