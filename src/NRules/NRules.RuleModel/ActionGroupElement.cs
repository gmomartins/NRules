using System.Collections.Generic;

namespace NRules.RuleModel
{
    /// <summary>
    /// Rule element that groups actions that run when the rule fires.
    /// </summary>
    public class ActionGroupElement : RuleRightElement
    {
        private readonly List<Declaration> _declarations;
        private readonly List<ActionElement> _actions;

        internal ActionGroupElement(IEnumerable<Declaration> declarations, IEnumerable<ActionElement> actions)
        {
            _declarations = new List<Declaration>(declarations);
            _actions = new List<ActionElement>(actions);
        }

        /// <summary>
        /// List of actions the group element contains.
        /// </summary>
        public IEnumerable<ActionElement> Actions
        {
            get { return _actions; }
        }

        public override IEnumerable<Declaration> Declarations
        {
            get { return _declarations; }
        }

        internal override void Accept<TContext>(TContext context, RuleElementVisitor<TContext> visitor)
        {
            visitor.VisitActionGroup(context, this);
        }
    }
}