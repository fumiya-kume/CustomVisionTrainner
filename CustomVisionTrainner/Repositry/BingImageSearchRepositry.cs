using CustomVisionTrainner.Entity;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionTrainner.Repositry
{
    public class BingImageSearchRepositry : IBingImageSearchRepositry
    {
        public ReactiveCollection<MemberImageData> ImageURLList { get; set; } = new ReactiveCollection<MemberImageData>();

        public async void GetImage()
        {

        }
    }
}
