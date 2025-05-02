// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Identity
{
    /// <summary>
    /// The default implementation of <see cref="IdentityClaim{TKey}"/> which uses a string as the primary key.
    /// </summary>
    public class IdentityClaim : IdentityClaim<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityClaim"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public IdentityClaim()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityClaim"/>.
        /// </summary>
        /// <param name="claimName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public IdentityClaim(string claimName) : this()
        {
            Name = claimName;
        }
    }

    /// <summary>
    /// Represents a role in the identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
    public class IdentityClaim<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityClaim{TKey}"/>.
        /// </summary>
        public IdentityClaim() { }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityClaim{TKey}"/>.
        /// </summary>
        /// <param name="claimName">The role name.</param>
        public IdentityClaim(string claimName) : this()
        {
            Name = claimName;
        }

        /// <summary>
        /// Gets or sets the primary key for this role.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// ClaimType
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public virtual string Code {get;set;}

        /// <summary>
        /// Gets or sets the name for this role.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name for this role.
        /// </summary>
        public virtual string NormalizedName { get; set; }

        /// <summary>
        /// A random value that should change whenever a role is persisted to the store
        /// </summary>
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Description
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Enable
        /// </summary>
        public virtual bool Enable{get;set;}

        /// <summary>
        /// Returns the name of the role.
        /// </summary>
        /// <returns>The name of the role.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
