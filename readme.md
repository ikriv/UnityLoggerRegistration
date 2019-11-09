# Unity Logger Registration

Demonstrates how
- Unity can resolve an IEnumerable&lt;T&gt; to a collection of instances of registered types
- How this feature can be used  to initialize a global list of formatters, and
- How we are better off not using thsi feature and making the list of formatters explicit.

Branch "magic" relies on Unity to maintain the list of formatters.
Branch "master" has explicit list of formatters.

See https://ikriv.com/blog/?p=4576 for more details.