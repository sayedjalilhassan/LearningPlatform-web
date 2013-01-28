using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4jClient;

namespace LearningPlatform.Models
{
    public class HasPrereqRelation : Relationship, IRelationshipAllowingSourceNode<Module>,
    IRelationshipAllowingTargetNode<Module>
    {
        public static readonly string TypeKey = "HasPreq";

        public HasPrereqRelation(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}