using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class CdrToJpgConverter
{
    static void Main()
    {
        // Path to the source CDR file
        string inputCdrPath = @"C:\Images\sample.cdr";

        // Desired output JPG file path
        string outputJpgPath = @"C:\Images\sample_converted.jpg";

        // Load the CDR file as a CdrImage
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputCdrPath))
        {
            // Optional: cache all pages to avoid lazy loading during save
            foreach (CdrImagePage page in cdrImage.Pages)
            {
                page.CacheData();
            }

            // Set JPEG save options (e.g., quality)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90 // Adjust quality as needed (0-100)
            };

            // Save the first page (or the whole image) as JPEG
            // If the CDR has multiple pages, you may iterate over them and save each separately.
            cdrImage.Save(outputJpgPath, jpegOptions);
        }
    }
}