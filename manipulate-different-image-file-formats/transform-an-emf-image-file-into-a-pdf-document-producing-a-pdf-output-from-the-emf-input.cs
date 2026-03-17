using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class EmfToPdfConverter
{
    static void Main()
    {
        // Path to the source EMF file
        string inputFile = @"C:\Temp\input.emf";

        // Desired path for the resulting PDF file
        string outputFile = @"C:\Temp\output.pdf";

        // Load the EMF image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options for vector formats (EMF in this case)
            // This ensures the vector data is correctly rendered when saved to PDF.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Use the original image size as the page size in the PDF
                PageSize = image.Size
            };

            // Set up PDF save options and attach the rasterization settings
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the loaded EMF image as a PDF document
            image.Save(outputFile, pdfOptions);
        }

        Console.WriteLine("EMF has been successfully converted to PDF.");
    }
}