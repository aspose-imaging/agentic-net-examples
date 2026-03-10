using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF image path
        string inputPath = "input.avif";

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Emboss filter is not available in Aspose.Imaging filter options.
            // Throwing NotSupportedException as per guidelines.
            throw new NotSupportedException("Emboss filter is not supported by Aspose.Imaging.");
        }
    }
}