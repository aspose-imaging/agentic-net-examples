using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png; // for PNG support
using Aspose.Imaging; // for Point struct

class Program
{
    static void Main()
    {
        // Load the base image that will receive the blending effect
        using (var baseImage = Image.Load("base.png"))
        {
            // Load the image that will be blended onto the base image
            using (var blendImage = Image.Load("blend.png"))
            {
                // Configure the alpha blending filter options
                var blendOptions = new ImageBlendingFilterOptions
                {
                    // The image to blend with the base image
                    Image = blendImage,
                    // Opacity of the blend image (0.0 = fully transparent, 1.0 = fully opaque)
                    Opacity = 0.6f,
                    // Blending mode (e.g., Normal, Multiply, Screen, etc.)
                    BlendingMode = BlendingMode.Normal,
                    // Position where the blend image will be placed on the base image
                    Position = new Point(0, 0)
                };

                // Apply the blending filter to the base image
                baseImage.ApplyFilter(blendOptions);
            }

            // Save the resulting image with the applied blending effect
            baseImage.Save("output.png");
        }
    }
}