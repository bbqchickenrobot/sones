﻿/*
* sones GraphDB - Community Edition - http://www.sones.com
* Copyright (C) 2007-2011 sones GmbH
*
* This file is part of sones GraphDB Community Edition.
*
* sones GraphDB is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, version 3 of the License.
* 
* sones GraphDB is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with sones GraphDB. If not, see <http://www.gnu.org/licenses/>.
* 
*/

using System;
using sones.Library.ErrorHandling;

namespace sones.Library.PropertyHyperGraph.ErrorHandling
{
    /// <summary>
    /// An exception for non existing binary properties.
    /// </summary>
	public class BinaryNotExistentException : ASonesException
    {
        #region data

        /// <summary>
        /// The binary property id.
        /// </summary>
        public readonly Int64 PropertyID;

        #endregion

        #region constructor
        
        /// <summary>
        /// Creates a new binary not existent exception.
        /// </summary>
        /// <param name="myPropertyID">The binary property id.</param>
        public BinaryNotExistentException(Int64 myPropertyID)
        {
            PropertyID = myPropertyID;
        }

        #endregion

    }
}