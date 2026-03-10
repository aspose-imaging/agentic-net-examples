using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomToPngConverter
{
    static void Main()
    {
        // Path to the source DICOM file
        string dicomFilePath = @"C:\Temp\sample.dcm";

        // Directory where PNG files will be saved
        string outputDirectory = @"C:\Temp\Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the DICOM image from a file stream
        using (FileStream stream = File.OpenRead(dicomFilePath))
        {
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                int pageIndex = 0;

                // Iterate through each page in the DICOM file
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the PNG file name based on the page index
                    string pngFilePath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                    // Save the current DICOM page as a PNG image
                    dicomPage.Save(pngFilePath, new PngOptions());

                    pageIndex++;
                }
            }
        }
    }
}