using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4jClient;

namespace LearningPlatform.Models
{
    public class HasCompletedRelation: Relationship, IRelationshipAllowingSourceNode<User>,
    IRelationshipAllowingTargetNode<Module>
    {
        public static readonly string TypeKey = "HasCompleted";

        public HasCompletedRelation(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}