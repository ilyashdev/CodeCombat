import { $host } from ".";

const course = [
  {
    idCourse: 1,
    idMoudle: 1101,
    typeModule: "flashcard",
    nameModle: "Name",
    data: [
      {
        id: 1,
        quetion: "# Default quetion1? \n- Some text \n- Some other text",
        answer: "# Default answer1",
      },
      {
        id: 2,
        quetion: "# Default quetion2? \n- Some text \n- Some other text",
        answer: "# Default answer2",
      },
      {
        id: 3,
        quetion: "# Default quetion3? \n- Some text \n- Some other text",
        answer: "# Default answer3",
      },
      {
        id: 4,
        quetion: "# Default quetion4? \n- Some text \n- Some other text",
        answer: "# Default answer4",
      },
      {
        id: 5,
        quetion: "# Default quetion5? \n- Some text \n- Some other text",
        answer: "# Default answer5",
      },
    ],
  },
  {
    idCourse: 1,
    idMoudle: 228,
    typeModule: "text",
    nameModle: " Разновидности структур алгоритмов",
    data: [
      {
        text: '\n~~~js\nconsole.log("fgggg")\n~~~\n\n|dddd|dddd|\n| - | - |\n![This is a caption and image alt property](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMAta6gQwho9exEBTDnGPMav7M2Lawbrog8A&s)\n\n> [!note] This is a _non-collapsible_ callout  \n> Some content is displayed directly!\n\n##### Структуры ~алгоритмов~:\n- *Линейная* - направление вычислений является единственным\n- *Разветвляющиеся* - направление вычислений определяется условиями\n- *Циклическая* - отдельные участки могут выполняться многократно\n \n$\\overline{a_n a_{n-1} a_{n-2} ... a_1 a_0(p)}=a_n p^n+a_{n-1}p^{n-1}+...+a_0 p^0=\\sum_{i=0}^n a_i p^i$ \n* Lists\n* [ ] todo\n* [x] done\n**Цикл** - участок схемы, многократно повторяющийся в ходе вычислений\n##### **Циклы** #####\n###### По взаимному расположению:\n- *Простые* - внутри нет другого цикла\n- *Сложные* - внутри есть другой цикл\n- *Вложенный(внутренний)* - внутри цикла\n- *Внешний* - не внутри цикла\n###### По месту условия:\n- С предусловием\n- С постусловием\n\n###### По виду условия цикла:\n- *Итерационные* - повторения не известны и получаются в ходе вычислений\n- *С параметром* - с известным числом повторений\n\n#### Восходящее проектирование:\n- Начинается с простых алгоритмов\n- Простые объединяются в более сложные\n- Объединения продолжаются до тех пор, пока не будет получен алгоритм решения всей задачи\n\n#### Нисходящее проектирование:\n- Разрабатывается алгоритм решения всей задачи в общем виде\n- Этапы алгоритма упрощаются пока не будет достигнут требуемый уровень детализации',
      },
    ],
  },
  {
    idCourse: 1,
    idMoudle: 315,
    typeModule: "code",
    nameModle: "Name",
    data: [
      {
        text: "# default",
        lang: "js",
        testID: 1233,
      },
    ],
  },
  {
    idCourse: 1,
    idMoudle: 4,
    typeModule: "test",
    nameModle: "Тесты",
    data: [
      {
        question: "# default",
        mode: "oneAns",
        variants: ["12", "167", "не знаю", "ничего из"],
      },
      {
        question: "# default",
        mode: "manyAns",
        variants: ["12", "167", "1457", "ничего из"],
      },
    ],
  },
];

export const CourseAPI = {
  getStructCourse: async (CourseId, nameId) => {
    const data = JSON.parse(
      `[{"idCourse":1,"Name":"Курс номер 1","data":[{"id":1,"type":"flashcard","name":"Name"},{"id":2,"type":"text","name":"Za"},{"id":3,"type":"code","name":"Practic"},{"id":4,"type":"test","name":"Тесты"}]},{"idCourse":2,"Name":"Курс номер 2","data":[{"id":1,"type":"flashcard","name":"Name"},{"id":2,"type":"text","name":"Za"},{"id":3,"type":"code","name":"Practic"}]},{"idCourse":3,"Name":"Курс номер 3","data":[{"id":1,"type":"flashcard","name":"Name"},{"id":2,"type":"text","name":"Za"},{"id":3,"type":"code","name":"Practic"}]},{"idCourse":4,"Name":"Курс номер 4","data":[{"id":1,"type":"flashcard","name":"Name"},{"id":2,"type":"text","name":"Za"},{"id":3,"type":"code","name":"Practic"}]},{"idCourse":5,"Name":"Курс номер 5","data":[{"id":1,"type":"flashcard","name":"Name"},{"id":2,"type":"text","name":"Za"},{"id":3,"type":"code","name":"Practic"}]},{"idCourse":6,"Name":"Курс номер 6","data":[{"id":1,"type":"flashcard","name":"Name"},{"id":2,"type":"text","name":"Za"},{"id":3,"type":"code","name":"Practic"}]}]`
    )[--CourseId];
    if (nameId == data.Name) return data;
    return window.location.replace("/NotFound");
  },
  getModule: async (CourseId, ModuleId) => {
    return await course[--ModuleId];
  },
  getTopCourse: async () => {
    return await JSON.parse(
      `[{"id":1,"name":"Курс номер 1","description":"Этот курс написан для проверки (номер 1)","firstModule":{"id":1,"name":"Name"}},{"id":2,"name":"Курс номер 2","description":"Этот курс написан для проверки (номер 2)","firstModule":{"id":1,"name":"Name"}},{"id":3,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)","firstModule":{"id":1,"name":"Name"}},{"id":4,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":5,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":6,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":7,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":8,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":9,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":10,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":11,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":12,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":13,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":14,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":15,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"}]`
    ).slice(0, 2);
  },
  getCurrentCountCourse: async (page, count) => {
    console.log(page);
    return await JSON.parse(
      `[{"id":1,"name":"Курс номер 1","description":"Этот курс написан для проверки (номер 1)","firstModule":{"id":1,"name":"Name"}},{"id":2,"name":"Курс номер 2","description":"Этот курс написан для проверки (номер 2)","firstModule":{"id":1,"name":"Name"}},{"id":3,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)","firstModule":{"id":1,"name":"Name"}},{"id":4,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":5,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":6,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":7,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":8,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":9,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":10,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":11,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":12,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":13,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":14,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"},{"id":15,"name":"Курс номер 3","description":"Этот курс написан для проверки (номер 3)"}]`
    ).slice((page - 1) * count, count * page);
  },
};
