// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using NuGet.Shared;

namespace NuGet.Packaging
{
    public class PackageHashFile : IEquatable<PackageHashFile>
    {
        public int Version { get; set; } = PackageHashFileFormat.Version;

        public string ContentHash { get; set; }

        public bool Equals(PackageHashFile other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Version == other.Version &&
                ContentHash.Equals(other.ContentHash);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PackageHashFile);
        }

        public override int GetHashCode()
        {
            var combiner = new HashCodeCombiner();

            combiner.AddObject(Version);
            combiner.AddSequence(ContentHash);

            return combiner.CombinedHash;
        }
    }
}