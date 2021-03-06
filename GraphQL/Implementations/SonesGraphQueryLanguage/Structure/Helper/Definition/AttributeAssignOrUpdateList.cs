/*
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sones.GraphQL.GQL.Structure.Helper.Definition.Update;
using sones.GraphQL.GQL.Structure.Nodes.Misc;

namespace sones.GraphQL.GQL.Structure.Helper.Definition
{
    /// <summary>
    /// Assign or update a list attribute
    /// </summary>
    public sealed class AttributeAssignOrUpdateList : AAttributeAssignOrUpdate
    {

        #region Properties

        public CollectionDefinition CollectionDefinition { get; private set; }
        public Boolean Assign { get; private set; }

        #endregion


        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myCollectionDefinition"></param>
        /// <param name="iDChainDefinition"></param>
        /// <param name="myAssign">True to assign, False to update</param>
        public AttributeAssignOrUpdateList(CollectionDefinition myCollectionDefinition, IDChainDefinition iDChainDefinition, Boolean myAssign)
        {
            CollectionDefinition = myCollectionDefinition;
            AttributeIDChain = iDChainDefinition;
            Assign = myAssign;
        }

        #endregion

    }
}
