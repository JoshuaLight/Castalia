﻿using Xunit;

namespace Pocket.Json.Tests.Complex
{
    public class JsonObjectTest : JsonTest
    {
        [Fact]
        public void Append_ShouldWorkCorrectly()
        {
            Appends(new IntAndInt()).As("{\"Item1\":0,\"Item2\":0}");
            Appends(new IntAndInt{ Item1 = 1 }).As("{\"Item1\":1,\"Item2\":0}");
            Appends(new IntAndInt{ Item1 = 1, Item2 = 2 }).As("{\"Item1\":1,\"Item2\":2}");
            
            Appends(new IntArray{ Items = new [] { 1, 2, 3, 4, 5 } })
                .As("{\"Items\":[1,2,3,4,5]}");
        }

        [Fact]
        public void Unwrap_ShouldWorkCorrectly()
        {
            Unwraps("{\"Item1\":0,\"Item2\":0}").As(new IntAndInt());
            Unwraps("{\"Item1\":1,\"Item2\":0}").As(new IntAndInt{ Item1 = 1 });
            Unwraps("{\"Item1\":1,\"Item2\":2}").As(new IntAndInt{ Item1 = 1, Item2 = 2 });
            
            Unwraps("{\"Items\":[1,2,3,4,5]}")
                .As(new IntArray{ Items = new [] { 1, 2, 3, 4, 5 } });
        }
    }
}