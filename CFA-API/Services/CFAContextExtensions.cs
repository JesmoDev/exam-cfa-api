using CFA_API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CFA_API.Services
{
    public static class CFAContextExtensions
    {
        public static void EnsureSeedDataForContext(this CFAContext contex)
        {
            if (contex.Sizes.Any())
            {
                return;
            }

            var sizes = new List<Size>
            {
                new Size
                {
                    Name = "XS"
                },
                new Size
                {
                    Name = "S"
                },
                new Size
                {
                    Name = "M"
                },
                new Size
                {
                    Name = "L"
                },
                new Size
                {
                    Name = "XL"
                },
                new Size
                {
                    Name = "XXL"
                },
            };

            contex.AddRange(sizes);
            contex.SaveChanges();
        }
    }
}
