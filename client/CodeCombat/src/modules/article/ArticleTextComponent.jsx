import { Card, Container, Spinner } from "react-bootstrap";
import ReactMarkdown from "react-markdown";
import { useSelector } from "react-redux";
import { CourseAPI } from "../../http/CourseAPI";
import { useQuery } from "@tanstack/react-query";
import remarkGfm from "remark-gfm";
import MarkdownText from "../general/MarkdownText";

const ArticleTextComponent = () => {
  const Md = `
  # Рекурсия
  ~~~cs
  static void Make(int n)
  {
    for (int i = n - 1; i >= 0; i--)
    {
      Console.Write(i.ToString() + " ");
      Make(i);
    }
  }
  
  public static void Main()
  {
    Make(4);
    Console.WriteLine();
  }
  ~~~
  Вывод данной программы:\n
  \`3 2 1 0 0 1 0 0 2 1 0 0 1 0 0\`\n
  Каждый новый вызов рекурсивной функции создаёт свой экземпляр в стеке, поэтому важно чтобы у рекурсии было то место, где она заканчивается, иначе получится бесконечная рекурсия, и по итогу мы получим \`StackOwerflowExeption\`
  # Дерево рекурсии
  Дерево рекурсий более наглядный способ показать вызовы рекурсий\n
  Эта визуализация позволяет считать сложность рекурсивного метода\n
  $p(0)=1$\n
  $p(n)=1+\\sum_{i=0}^{n-1} p(i)$\n
  Логически подумав(подставив парочку значений) можно увидеть, что: \n
  $p(n)=2^n$\n
  Докажем по индукции\n
  $p(n)=1+\\sum_{i=0}^{n-1} p(i)=1+2^n-1=2^n$\n
  ### Ещё пример
  Расмотрим ещё один рекурсивный метод:
  ~~~cs
  public static int Make(int x, int y)
  {
    if (x <= 0 || y <= 0) return 1;
    return Make(x - 1, y) + Make(x, y - 1);
  }
  ~~~
  Построим дерево рекурсии\n
  Ответ данного варианта можно легко увидеть по дереву (6)\n
  Рассчитаем сложность алгоритма:\n
  $p(0,y)=1$\n
  $p(x,0)=1$\n
  $p(x,y)=1+p(x−1,y)+p(x,y−1)$\n
  Рассмотрим сначала ограничение сверху:\n
  $p(x,y)≤3^{x+y}$ \n
  Докажем по индукции:\n
  $p(0,0) = 1 ≤ 3^0$\n
  $p(x,y)=1+p(x-1,y)+p(x,y-1)≤3^{x+y-1}+3^{x+y-1}+3^{x+y-1}=3^{x+y}$\n
  Далее рассмотрим ограничение снизу:\n
  $p'(0,y)=1$, $p'(x,0)=1$\n
  $p'(x,y)=p'(x-1,y)+p'(x,y-1)<p(x,y)$\n
  $p'(x,y)=C_{x+y}^x=\\frac{(x+y)!}{x!y!}$ \n
  $p(x,y)=Θ(2^{x+y})$ \n
  `;

  const { data, isPending, error } = useQuery({
    queryKey: ["article", "articleInfo", 1],
    queryFn: () =>
      Promise.resolve({
        nameArticle: "Рекурсивные алгоритмы",
        data: [
          {
            text: Md,
          },
        ],
      }),
  });

  if (isPending) return <Spinner />;
  return (
    <Container>
      <h2 className="mt-3">{data.nameArticle}</h2>
      <Card data-bs-theme="dark" className="p-3 m-2">
        {data.data.map((text) => (
          <MarkdownText key={text}>{text.text}</MarkdownText>
        ))}
      </Card>
    </Container>
  );
};

export default ArticleTextComponent;
