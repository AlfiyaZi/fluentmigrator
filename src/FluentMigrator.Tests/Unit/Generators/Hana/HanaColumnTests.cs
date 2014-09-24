﻿using FluentMigrator.Runner.Generators.Hana;
using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit.Generators.Hana
{
    [TestFixture]
    public class HanaColumnTests : BaseColumnTests
    {
        protected HanaGenerator Generator;

        [SetUp]
        public void Setup()
        {
            Generator = new HanaGenerator();
        }

        [Test]
        public override void CanAlterColumnWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");

            var expression = GeneratorTestHelper.GetAlterColumnExpression();
            expression.Column.IsNullable = null;
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ALTER (\"TestColumn1\" NVARCHAR(20))");
            //HANA Dosent suport SCHEMA YEAT
        }

        [Test]
        public override void CanAlterColumnWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetAlterColumnExpression();
            expression.Column.IsNullable = null;

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ALTER (\"TestColumn1\" NVARCHAR(20));");
        }

        [Test]
        public override void CanCreateAutoIncrementColumnWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");

            var expression = GeneratorTestHelper.GetAlterColumnAddAutoIncrementExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ALTER (\"TestColumn1\" INTEGER GENERATED BY DEFAULT AS IDENTITY)");
        }

        [Test]
        public override void CanCreateAutoIncrementColumnWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetAlterColumnAddAutoIncrementExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ALTER (\"TestColumn1\" INTEGER GENERATED BY DEFAULT AS IDENTITY);");
        }

        [Test]
        public override void CanCreateColumnWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");
            var expression = GeneratorTestHelper.GetCreateColumnExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ADD (\"TestColumn1\" NVARCHAR(5))");
        }

        [Test]
        public override void CanCreateColumnWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateColumnExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ADD (\"TestColumn1\" NVARCHAR(5));");
        }

        [Test]
        public override void CanCreateDecimalColumnWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");

            var expression = GeneratorTestHelper.GetCreateDecimalColumnExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ADD (\"TestColumn1\" DECIMAL(19,2))");
        }

        [Test]
        public override void CanCreateDecimalColumnWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateDecimalColumnExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" ADD (\"TestColumn1\" DECIMAL(19,2));");
        }

        [Test]
        public override void CanDropColumnWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");

            var expression = GeneratorTestHelper.GetDeleteColumnExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" DROP (\"TestColumn1\")");
        }

        [Test]
        public override void CanDropColumnWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteColumnExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" DROP (\"TestColumn1\");");
        }

        [Test]
        public override void CanDropMultipleColumnsWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");

            var expression = GeneratorTestHelper.GetDeleteColumnExpression(new[] { "TestColumn1", "TestColumn2" });
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" DROP (\"TestColumn1\");" 
                + System.Environment.NewLine +
                "ALTER TABLE \"TestTable1\" DROP (\"TestColumn2\")");
        }

        [Test]
        public override void CanDropMultipleColumnsWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteColumnExpression(new[] { "TestColumn1", "TestColumn2" });

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE \"TestTable1\" DROP (\"TestColumn1\");"
                + System.Environment.NewLine +
                "ALTER TABLE \"TestTable1\" DROP (\"TestColumn2\");");
        }

        [Test]
        public override void CanRenameColumnWithCustomSchema()
        {
            Assert.Ignore("Hana support change default value with type like bellow");

            var expression = GeneratorTestHelper.GetRenameColumnExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("RENAME COLUMN \"TestTable1\".\"TestColumn1\" TO \"TestColumn2\"");
        }

        [Test]
        public override void CanRenameColumnWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetRenameColumnExpression();
            expression.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("RENAME COLUMN \"TestTable1\".\"TestColumn1\" TO \"TestColumn2\";");
        }
    }
}